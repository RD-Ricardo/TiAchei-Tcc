using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;
        public UserController(UserManager<User> userManager,
            SignInManager<User> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user != null)
            {
                var result = await _signManager.PasswordSignInAsync(user, model.Senha,false,false);

                if(result.Succeeded)
                {   
                    return RedirectToAction("","");
                }
                else
                {
                    return RedirectToAction("","");
                }
            }
            else
            {
                ModelState.AddModelError("","");
                return View(model);
            }
            
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel  model)
        {
            return Ok();
        }

    }

}