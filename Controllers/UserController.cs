using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TiAchei_Tcc.Models;
using TiAchei_Tcc.Services;
using TiAchei_Tcc.ViewModel;

namespace TiAchei_Tcc.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signManager;
        private readonly ServiceUploadFile _serviceUpload;
        
        public UserController(UserManager<User> userManager,
            SignInManager<User> signManager, ServiceUploadFile serviceUpload)
        {
            _userManager = userManager;
            _signManager = signManager;
            _serviceUpload = serviceUpload;
           
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
            if(!ModelState.IsValid) return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user != null)
            {
                var result = await _signManager.PasswordSignInAsync(user, model.Senha,false,false);

                if(result.Succeeded)
                {   
                    if(string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return RedirectToAction("Index","Painel");
                    }
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("Senha","Senha incorreta");
                    return View(model);
                }
            }
            ModelState.AddModelError("","Usuario não encontrado");
            return View(model);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(RegisterViewModel  model)
        {
            if(ModelState.IsValid)
            {
                var user = new User()
                {
                    Email = model.Email, 
                    UserName = model.Nome,
                    PhoneNumber = model.Telefone,
                    UrlFacebook = model.UrlFacebook,
                    UrlInstagram = model.UrlInstagram,
                    FotoUrl = _serviceUpload.UploadFile(model)
                };
                
                var result = await _userManager.CreateAsync(user, model.Senha);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Painel");
                }
                else
                {
                    this.ModelState.AddModelError("Cadastra", "Falha ao cadastrar usuário.");
                }
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return  RedirectToAction("Index","Home");
        }
    }
}