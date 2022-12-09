using iDev.Application.InputModels;
using iDev.Application.ViewModels;

namespace iDev.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetUser(int id);
        int Create(CreateUserInputModel inputModel);
    }
}
