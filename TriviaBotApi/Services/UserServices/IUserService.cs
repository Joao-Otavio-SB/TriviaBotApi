using TriviaBotApi.DTO_s;
using TriviaBotApi.Models;

namespace TriviaBotApi.Services.UserServices
{
    public interface IUserService
    {
        public UserModel GetUserById(int id);

        public Task<UserModel> SetUser(RegisterUserDTO user, byte[] passwordHash, byte[] passwordSalt);

        public Task<UserModel> UpdateUser(UpdateUserDTO user);

        public Task<List<UserModel>> DeleteUserById(int id);
    }
}
