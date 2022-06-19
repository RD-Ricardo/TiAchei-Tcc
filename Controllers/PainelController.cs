using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TiAchei_Tcc.Extensions;
using TiAchei_Tcc.Models;
using TiAchei_Tcc.Repository.Interfaces;
using TiAchei_Tcc.Services;
using TiAchei_Tcc.ViewModel;

namespace TiAchei_Tcc.Controllers
{
    [Authorize]
    public class PainelController: Controller
    {   
        private readonly IPetRepository _repository;
        private readonly UserManager<User> _userManager;
        private readonly ServiceUploadFile _serviceUpload;
        public PainelController(IPetRepository repository,  UserManager<User> userManager , 
                ServiceUploadFile serviceUpload)
        {
            _userManager = userManager;
            _repository = repository;
            _serviceUpload = serviceUpload;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {  
            var userCurrent = await _userManager.GetUserAsync(User); 
            
            var resultPets = await _repository.GetAllPetsUserCurrent(userCurrent);

            var viewModel = new PainelViewModel()
            {
                Pets = resultPets,
                Usuario = userCurrent
            };

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Buscar(string id)
        {   
            var model = await _repository.GetBydId(id);
            return Json(model);
        }
        [HttpDelete]
        public async Task<IActionResult> Deletar(string id)
        {   
            var model = await _repository.DeletePet(id);
            if(model) return Ok();
            else return BadRequest();
        }

        [HttpGet]
        public IActionResult CadastrarPet()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPet(PetViewModel model)
        {
            var userCurrent = await _userManager.GetUserAsync(User);
    
            var petCurrent =  new Pet()
            {
                Nome = model.Nome,
                Raca = model.Raca,
                Foto = _serviceUpload.UploadFilePet(model),
                Perdido = false,
                UserId = userCurrent.Id,
                Tipo = model.Tipo,
                Descricao = model.Descricao 
            };
            await _repository.CreatePet(petCurrent);
            this.MostrarMensagem("Pet Cadastrado com sucesso", TipoMensagem.Sucesso);
            return RedirectToAction("CadastrarPet");             
        }
        [HttpGet]
        public async Task<IActionResult> Editar(string id)
        {   var model = await  _repository.GetBydId(id);
           return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Editar([FromForm]Pet model)
        {
            var userCurrent = await _userManager.GetUserAsync(User);
            model.UserId = userCurrent.Id;
            if(!await _repository.Update(model)) return BadRequest("Deu erro o loko");
            return RedirectToAction("Index", "Painel");
        }

        [HttpGet]
        public IActionResult Pessoas() => View();
        
        [HttpGet]
        public IActionResult Objetos() => View();

        [HttpGet]
        public async Task<IActionResult> Config()
        {   
            User model = await _userManager.GetUserAsync(User);
            return  View(model);
        }
    
    }
}