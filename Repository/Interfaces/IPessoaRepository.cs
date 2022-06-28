using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.Repository.Interfaces{
    public interface IPessoaRepository
    {
        Task<Pessoa> GetBydId(string id);
        Task<List<Pessoa>> GetAllPessoasUserCurrent(User model);
        Task<List<EnfermidadePessoa>> GetAllCategoriesPessoasUserCurrent(User model);
        Task CreatePessoa(Pessoa model);
        Task<bool> Update(Pessoa newModel);
        Task<bool> DeletePessoa(string id);
        Task CreateCategoryPessoa(EnfermidadePessoa model);
    }
}