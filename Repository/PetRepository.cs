using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public  async Task CreateCategoryPet(CategoriaPet model)
        {
            await _dbContext.CategoriaPets.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreatePet(Pet model)
        {
            await _dbContext.Pets.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeletePet(string id)
        {
            var petResult = await GetBydId(id);
            if(petResult == null) return false;
            _dbContext.Pets.Remove(petResult);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<CategoriaPet>> GetAllCategoriesPetsUserCurrent(User model)
            => await _dbContext.CategoriaPets.Where(x => x.UserId == model.Id).ToListAsync();

        public async Task<List<Pet>> GetAllPetsUserCurrent(User model)
            =>  await _dbContext.Pets.Include(x => x.Categoria).Where(c  => c.UserId == model.Id).ToListAsync();
        
        public async Task<Pet> GetBydId(string id) 
            => await _dbContext.Pets.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<bool> Update(Pet newModel)
        {
           _dbContext.Pets.Update(newModel);
           return await _dbContext.SaveChangesAsync() > 0 ?  true : false;
        }
    }
}