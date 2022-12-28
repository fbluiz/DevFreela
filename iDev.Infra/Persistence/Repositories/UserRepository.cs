using iDev.Core.Entities;
using iDev.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace iDev.Infra.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDevDbContext _dbcontext;

        public UserRepository(IDevDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddUserAsync(User user)
        {
            await _dbcontext.Users.AddAsync(user);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAndPasswordAsynnc(string email, string passwordHash)
        {
            return await _dbcontext
                .Users
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dbcontext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
