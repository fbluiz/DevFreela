
namespace iDev.Core.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
        string ComputerSha256Hash(string password); 
    }
}