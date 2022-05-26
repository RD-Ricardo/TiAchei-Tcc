using TiAchei_Tcc.Models;
namespace TiAchei_Tcc.Repository.Interfaces
{
    public interface IPetRepository
    {
        Task<Pet> GetBydId(string id);
        Task<List<Pet>> GetAllUserId();
        Task CreatePet(Pet model);
        Task<bool> DeletarPet(string id);
    }
}