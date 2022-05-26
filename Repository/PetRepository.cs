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

        public async Task<bool> DeletarPet(string id)
        {
            var petResult = await GetBydId(id);
            if(petResult == null) return false;
            _dbContext.Pets.Remove(petResult);
            if(await _dbContext.SaveChangesAsync() > 0){
                return true;
            }
            else{
                return false;
            }
        }

        public async Task<List<Pet>> GetAllUserId() => await _dbContext.Pets.ToListAsync();

        public async Task<Pet> GetBydId(string id) => await _dbContext.Pets.Where(x => x.Id == id).FirstOrDefaultAsync();
    }
}