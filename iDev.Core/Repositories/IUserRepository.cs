using iDev.Core.Entities;

namespace iDev.Core.Repositories
{
    public interface IUserRepository    
    {
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
    }
}
