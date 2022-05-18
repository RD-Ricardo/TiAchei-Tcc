using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TiAchei_Tcc.Models;
using TiAchei_Tcc.ViewModel;

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
        public IActionResult Login(string retrunUrl)
        {
            return View(new LoginViewModel(){
                ReturnUrl = retrunUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user != null)
            {
                var result = await _signManager.PasswordSignInAsync(user, model.Senha,false,false);

                if(result.Succeeded)
                {   
                    return RedirectToAction("Index","Painel");
                }
                else
                {
                    return View();
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
        public async Task<IActionResult> Register(RegisterViewModel  model)
        {
            var user = new User(){Email = model.Email, UserName = model.Nome};
            var result = await _userManager.CreateAsync(user, model.Senha);

            if(result.Succeeded)
            {
                return RedirectToAction("Painel","Home");
            }
            return RedirectToAction("Index","Home");
        }

    }

}