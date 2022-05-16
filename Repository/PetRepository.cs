using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using TiAchei_Tcc.Db;
using TiAchei_Tcc.Models;
using TiAchei_Tcc.Repository.Interfaces;

namespace TiAchei_Tcc.Repository
{
    public class PetRepository : IPetRepository
    {   private readonly AppDbContextMysql _dbContext;
        public PetRepository(AppDbContextMysql dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreatePet(Pet model)
        {
            await _dbContext.Pets.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        } 
        public async Task<List<Pet>> GetAllUserId() => await _dbContext.Pets.ToListAsync();
        
    }
}