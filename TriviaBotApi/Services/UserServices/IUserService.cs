using TriviaBotApi.DTO_s;
using TriviaBotApi.Models;

namespace TriviaBotApi.Services.UserServices
{
    public interface IUserService
    {
        public List<UserModel> GetAllUsers();

        public UserModel GetUserById(int id);

        public Task<UserModel> SetUser(SetUserDTO user);

        public Task<UserModel> UpdateUser(UpdateUserDTO user);

        public Task<List<UserModel>> DeleteUserById(int id);
    }
}
