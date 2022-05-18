using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TiAchei_Tcc.Models;
using TiAchei_Tcc.Repository.Interfaces;

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
            var model = await _repository.GetAllUserId();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Buscar(string id)
        {   
            var model = await _repository.GetBydId(id);
            return Json(model);
        }
    }
}