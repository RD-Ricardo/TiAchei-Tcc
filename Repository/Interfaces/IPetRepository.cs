using TiAchei_Tcc.Models;
namespace TiAchei_Tcc.Repository.Interfaces
{
    public interface IPetRepository
    {
        Task<Pet> GetBydId(string id);
        Task<List<Pet>> GetAllPetsUserCurrent(User model);
        Task CreatePet(Pet model);
        Task<bool> DeletarPet(string id);
    }
}