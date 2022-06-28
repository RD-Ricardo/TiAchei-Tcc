using Microsoft.EntityFrameworkCore;
using TiAchei_Tcc.Db;
using TiAchei_Tcc.Models;
using TiAchei_Tcc.Repository.Interfaces;

namespace TiAchei_Tcc.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContextMysql _dbContext; 
        public PessoaRepository(AppDbContextMysql dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateCategoryPessoa(EnfermidadePessoa model)
        {
            await _dbContext.EnfermidadePessoas.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreatePessoa(Pessoa model)
        {
            await _dbContext.Pessoas.AddAsync(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeletePessoa(string id)
        {
            var pessoaResult = await GetBydId(id);
            if(pessoaResult == null) return false;
            _dbContext.Pessoas.Remove(pessoaResult);
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<EnfermidadePessoa>> GetAllCategoriesPessoasUserCurrent(User model)
            => await _dbContext.EnfermidadePessoas.Where(x => x.UserId == model.Id).ToListAsync();        

        public async Task<List<Pessoa>> GetAllPessoasUserCurrent(User model)
         =>  await _dbContext.Pessoas.Include(x =>  x.Categoria).Where(c  => c.UserId == model.Id).ToListAsync();
        

        public async Task<Pessoa> GetBydId(string id) 
            => await _dbContext.Pessoas.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async  Task<bool> Update(Pessoa newModel)
        {
           _dbContext.Pessoas.Update(newModel);
           return await _dbContext.SaveChangesAsync() > 0 ?  true : false;
        }
    }
}