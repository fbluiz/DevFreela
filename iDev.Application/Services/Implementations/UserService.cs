using iDev.Application.InputModels;
using iDev.Application.Services.Interfaces;
using iDev.Application.ViewModels;
using iDev.Core.Entities;
using iDev.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iDev.Application.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly IDevDbContext _dbcontext;

        public UserService(IDevDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);
            
            _dbcontext.Users.Add(user);
            _dbcontext.SaveChanges();

            return user.Id;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _dbcontext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel(user.FullName, user.Email);
        }
    }
}
