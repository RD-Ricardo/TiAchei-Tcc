using Microsoft.EntityFrameworkCore;
using TiAchei_Tcc.Db;
using TiAchei_Tcc.Models;
using TiAchei_Tcc.Repository.Interfaces;

namespace TiAchei_Tcc.Repository
{
    public class UserRepository : IUserRepository
    {   
        private readonly AppDbContextMysql _dbrepository;
        public UserRepository( AppDbContextMysql dbrepository)
        {
            _dbrepository = dbrepository;
        }
        public async Task<Pet> GetUserUrl(string userId) => await _dbrepository.Pets.Where(c => c.Id == userId).FirstOrDefaultAsync();

    }
}