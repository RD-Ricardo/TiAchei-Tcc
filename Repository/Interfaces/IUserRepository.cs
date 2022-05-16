using TiAchei_Tcc.Models;

namespace TiAchei_Tcc.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserUrl(string userId);
    }
}