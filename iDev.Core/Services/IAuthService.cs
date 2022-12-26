
namespace iDev.Core.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
    }
}