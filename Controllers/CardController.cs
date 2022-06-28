using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiAchei_Tcc.Db;
using TiAchei_Tcc.Models;
using TiAchei_Tcc.Repository.Interfaces;

namespace TiAchei_Tcc.Controllers
{
    [Controller]
    public class CardController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly UserManager<User> _userManager;

        private AppDbContextMysql _dbcontext;
        public CardController(IUserRepository repository,UserManager<User> userManager,AppDbContextMysql dbcontext)
        {
            _repository = repository;
            _userManager = userManager;
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> Perfil(string id)
            => View(await _dbcontext.Pets.Include(c => c.Usuario)
                    .Where(c => c.Id == id).FirstOrDefaultAsync());
        
    }
}