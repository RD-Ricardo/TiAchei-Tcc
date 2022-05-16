using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TiAchei_Tcc.Models;
using TiAchei_Tcc.Repository.Interfaces;

namespace TiAchei_Tcc.Controllers
{
    [Controller]
    public class RegistroController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IPetRepository _repository;
        public RegistroController(UserManager<User> userManager, IPetRepository repository)
        {
            _userManager = userManager;
            _repository  = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Pet model)
        {
            // var userCurrent = await _userManager.GetUserAsync(User);
            if(ModelState.IsValid){

                var petCurrent =  new Pet()
                {
                    Nome = model.Nome,
                    Foto = model.Foto,
                    Perdido = model.Perdido,
                    UserId = "28888d2b-b1f1-4b23-9026-50b128937973",
                    Tipo = model.Tipo,
                    Descricao = model.Descricao 
                };
                
                await _repository.CreatePet(petCurrent);
                return RedirectToAction("Index","Pet");
            }
            else
            {
                ViewBag.Erro =  "Erro ao enviar os dados";
                return View();
            }                        
        }
    }
}