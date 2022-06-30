using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IPessoaRepository _repositoryPessoa;
        private readonly UserManager<User> _userManager;
        private readonly ServiceUploadFile _serviceUpload;
        public PainelController(IPetRepository repository,  UserManager<User> userManager , 
                ServiceUploadFile serviceUpload,
                IPessoaRepository repositoryPessoa)
        {
            _userManager = userManager;
            _repository = repository;
            _repositoryPessoa = repositoryPessoa;
            _serviceUpload = serviceUpload;
        }

        [HttpGet]
        public async Task<IActionResult> Buscar(string id) => Json(await _repository.GetBydId(id));

        [HttpGet]
        public async Task<IActionResult> BuscarPessoa(string id) => Json(await _repositoryPessoa.GetBydId(id));
        
        [HttpGet]
        public async Task<IActionResult> Objetos() => View(await _userManager.GetUserAsync(User));

        [HttpDelete]
        public async Task<IActionResult> Deletar(string id) => await _repository.DeletePet(id) ? Ok() : BadRequest();
        [HttpDelete]
        public async Task<IActionResult> DeletarPessoa(string id) => await _repositoryPessoa.DeletePessoa(id) ? Ok() : BadRequest();
        
        [HttpGet]
        public async Task<IActionResult> Index() 
            => View(new PainelViewModel() 
            {
                Pets = await _repository.GetAllPetsUserCurrent(await _userManager.GetUserAsync(User)),
                Usuario = await _userManager.GetUserAsync(User)
            });
            
       
         
        [HttpGet]
        public async Task<IActionResult> CadastrarPet() 
        {
            ViewBag.CategoryId = new SelectList(await _repository.GetAllCategoriesPetsUserCurrent(await _userManager.GetUserAsync(User)),"Id", "Nome");
            return View();
        } 
        
        [HttpPost]
        public async Task<IActionResult> CadastrarPet(PetViewModel model)
        {
            if(ModelState.IsValid)
            {
                var petCurrent = new Pet()
                {
                    Nome = model.Nome,
                    Raca = model.Raca,
                    Foto = _serviceUpload.UploadFilePet(model),
                    Perdido = false,
                    CategoriaPetId = model.CategoriaPetId,
                    UserId = _userManager.GetUserId(User),
                    Descricao = model.Descricao 
                };
                await _repository.CreatePet(petCurrent);
                this.MostrarMensagem("Pet Cadastrado com sucesso", TipoMensagem.Sucesso);
                return RedirectToAction("CadastrarPet");             
            }
            else
            {
                ViewBag.CategoryId = new SelectList(await _repository.GetAllCategoriesPetsUserCurrent(await _userManager.GetUserAsync(User)),"Id", "Nome");
                this.ModelState.AddModelError("Cadastra", "Falha ao cadastrar usuário.");
                this.MostrarMensagem("Falha ao Cadastrar", TipoMensagem.Erro);
                return View(model);
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Pessoas()
            => View(new PagePessoaViewModel()
            {
                Pessoas = await _repositoryPessoa.GetAllPessoasUserCurrent(await _userManager.GetUserAsync(User)),
                Usuario = await _userManager.GetUserAsync(User)
            });
            
        
        [HttpGet]
        public async Task<IActionResult> CadastrarPessoa() 
        {
            ViewBag.CategoryId = new SelectList(await _repositoryPessoa.GetAllCategoriesPessoasUserCurrent(await _userManager.GetUserAsync(User)),"Id", "Nome");
            return View();
        } 

        [HttpPost]
        public async Task<IActionResult> CadastrarPessoa(PessoaViewModel model)
        {    
            var pessoaCurrent =  new Pessoa()
            {
                Nome = model.Nome,
                Idade = model.Idade,
                FotoUrl = _serviceUpload.UploadFilePessoa(model),
                Perdido = false,
                Categoria = model.Categoria,
                UserId = _userManager.GetUserId(User),
                Descricao = model.Descricao,
                DataCriacao = DateTime.Now,
                EnfermidadePessoaId = model.EnfermidadePessoaId 
            };
            await _repositoryPessoa.CreatePessoa(pessoaCurrent);
            this.MostrarMensagem("Pessoa cadastrada com sucesso", TipoMensagem.Sucesso);
            return RedirectToAction("CadastrarPet");             
        }
        
        [HttpGet]
        public  IActionResult CadastrarEnfermidadePessoa() => View();
        [HttpPost]
        public async Task<IActionResult> CadastrarEnfermidadePessoa(PessoaViewModel model)
        {
                
            var categoriaPessoaa = new EnfermidadePessoa()
            {
                Nome = model.Nome,
                UserId = _userManager.GetUserId(User)
            };
            await _repositoryPessoa.CreateCategoryPessoa(categoriaPessoaa);
            this.MostrarMensagem("Categoria cadastrada com sucesso", TipoMensagem.Sucesso);
            return RedirectToAction("CadastrarCategoriaPessoa");             
        }

        [HttpGet]
        public  IActionResult CadastrarCategoriaPet() => View();
        
        [HttpPost]
        public async Task<IActionResult> CadastrarCategoriaPet(CategoriaPet model)
        {
            var categoria = new CategoriaPet()
            {
                Nome = model.Nome,
                UserId = _userManager.GetUserId(User)
            };
            await _repository.CreateCategoryPet(categoria);
            this.MostrarMensagem("categoria cadastrada com sucesso", TipoMensagem.Sucesso);
            return RedirectToAction("CadastrarCategoriaPet");             
        }
        
        [HttpGet]
        public async Task<IActionResult> Editar(string id) 
        {

            ViewBag.CategoryId = new SelectList(await _repository.GetAllCategoriesPetsUserCurrent(await _userManager.GetUserAsync(User)),"Id", "Nome");
            return View(await  _repository.GetBydId(id));
        } 

        [HttpPost]
        public async Task<IActionResult> Editar([FromForm]Pet model)
        {
            var userCurrent = await _userManager.GetUserAsync(User);
            model.UserId = userCurrent.Id;
            if(!await _repository.Update(model)) return BadRequest();
            return RedirectToAction("Index", "Painel");
        }


        [HttpGet]
        public async Task<IActionResult> Config() => View(await _userManager.GetUserAsync(User));
        [HttpPost]
        public async Task<IActionResult> Config([FromForm]User mode) 
        {
           var update = await _userManager.UpdateAsync(mode);
           if(update.Succeeded)
           {
                return View("Index");
           }
           return View();
        } 
    
    }
}