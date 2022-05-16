using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiAchei_Tcc.Models;
using TiAchei_Tcc.Repository.Interfaces;

namespace TiAchei_Tcc.Controllers
{
    [Controller]
    public class CardController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserManager<User> _userManager;
        public CardController(IUserRepository repository,UserManager<User> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string userId)
        {
            var result = await _repository.GetUserUrl(userId);
            return View(result);
        }
    }
}