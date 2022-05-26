using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TiAchei_Tcc.Models;
using TiAchei_Tcc.Repository.Interfaces;
using TiAchei_Tcc.Services;
using TiAchei_Tcc.ViewModel;

namespace TiAchei_Tcc.Controllers
{
    [Authorize]
    // [Controller]
    // [Route("[controller]")]
    public class PainelController: Controller
    {   
        private readonly IPetRepository _repository;
        private readonly UserManager<User> _userManager;
        public PainelController(IPetRepository repository,  UserManager<User> userManager)
        {
            _userManager = userManager;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {   
           
            var resultPets = await _repository.GetAllUserId();
            var userCurrent = await _userManager.GetUserAsync(User);

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
            var model = await _repository.DeletarPet(id);
            if(model)
            {
                return Ok();
            }
            else{
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Pet model)
        {
            var userCurrent = await _userManager.GetUserAsync(User);
    
                var petCurrent =  new Pet()
                {
                    Nome = model.Nome,
                    Raca = model.Raca,
                    Foto = "test",
                    Perdido = false,
                    UserId = userCurrent.Id,
                    Tipo = model.Tipo,
                    Descricao = model.Descricao 
                };
            
                await _repository.CreatePet(petCurrent);
                return RedirectToAction("Index","Painel");             
        }

        [HttpGet]
        public IActionResult Qrcode(string id)
        {
            var url = HttpContext.Request.Host.Value;
            ViewBag.HostUrl =  url;
            ViewBag.Id =  id;
            return View();
        }
    }
}