using Microsoft.EntityFrameworkCore;
using TriviaBotApi.Data;
using TriviaBotApi.DTO_s;
using TriviaBotApi.Models;

namespace TriviaBotApi.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<UserModel>> DeleteUserById(int id)
        {
            var deletedUser = GetUserById(id);

            _dataContext.Remove(deletedUser);
            await _dataContext.SaveChangesAsync();

            var users = GetAllUsers();

            return users;
        }

        private List<UserModel> GetAllUsers()
        {
            var users = _dataContext.Users.Include(user => user.GameStats).ToList();

            return users;
        }

        public UserModel GetUserById(int id)
        {
            var user = _dataContext.Users.Where(user => user.Id == id).Include(user => user.GameStats);

            if (!user.Any()) return null;

            return user.First();   
        }

        public async Task<UserModel> SetUser(RegisterUserDTO user, byte[] passwordHash, byte[] passwordSalt)
        {
            var newUser = new UserModel()
            {
                UserName = user.UserName,
                Email = user.UserEmail,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _dataContext.Users.Add(newUser);
            await _dataContext.SaveChangesAsync();

            return newUser;
        }

        public async Task<UserModel> UpdateUser(UpdateUserDTO user)
        {
            var newUser = GetUserById(user.UserId);

            if (newUser == null) return null;

            newUser.UserName = user.UserName;
            newUser.Email = user.UserEmail;

            _dataContext.Users.Update(newUser);
            await _dataContext.SaveChangesAsync();

            var users = GetAllUsers();

            return newUser;
        }
    }
}
