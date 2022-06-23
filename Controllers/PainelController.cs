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
        public async Task<IActionResult> Buscar(string id) => Json(await _repository.GetBydId(id));
    
        [HttpGet]
        public async Task<IActionResult> Pessoas() => View(await _userManager.GetUserAsync(User));
        
        [HttpGet]
        public async Task<IActionResult> Objetos() => View(await _userManager.GetUserAsync(User));

        [HttpGet]
        public  async Task<IActionResult> CadastrarPet() => View(await _userManager.GetUserAsync(User));
        [HttpGet]
        public  async Task<IActionResult> CadastrarPessoa() => View(await _userManager.GetUserAsync(User));

        [HttpGet]
        public async Task<IActionResult> Config() => View(await _userManager.GetUserAsync(User));

        [HttpGet]
        public async Task<IActionResult> Editar(string id) => View(await  _repository.GetBydId(id));
        [HttpDelete]
        public async Task<IActionResult> Deletar(string id) => await _repository.DeletePet(id) ? Ok() : BadRequest();
        
        [HttpGet]
        public async Task<IActionResult> Index() 
            => View(new PainelViewModel() 
            {
                Pets = await _repository.GetAllPetsUserCurrent(await _userManager.GetUserAsync(User)),
                Usuario = await _userManager.GetUserAsync(User)
            });
            
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
                Descricao = model.Descricao 
            };
            await _repository.CreatePet(petCurrent);
            this.MostrarMensagem("Pet Cadastrado com sucesso", TipoMensagem.Sucesso);
            return RedirectToAction("CadastrarPet");             
        }

        
        
        
        [HttpPost]
        public async Task<IActionResult> Editar([FromForm]Pet model)
        {
            var userCurrent = await _userManager.GetUserAsync(User);
            model.UserId = userCurrent.Id;
            if(!await _repository.Update(model)) return BadRequest();
            return RedirectToAction("Index", "Painel");
        }
    
    }
}