using TriviaBotApi.DTO_s;
using TriviaBotApi.Models;

namespace TriviaBotApi.Services.AuthServices
{
    public interface IAuthService
    {
        Task<UserModel> Register(RegisterUserDTO user);

        Task<string> Login(string userEmail, string password);

        Task<bool> UserAlreadyExists(string userEmail);

        bool IsUserLogged(string token);
    }
}
