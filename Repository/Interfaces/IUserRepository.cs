using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<Pet> GetUserUrl(string userId);
    }
}