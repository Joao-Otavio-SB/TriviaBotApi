using Microsoft.EntityFrameworkCore;
using TriviaBotApi.Data;
using TriviaBotApi.DTO_s;
using TriviaBotApi.Models;

namespace TriviaBotApi.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<IUserService> _logger;

        public UserService(DataContext dataContext, ILogger<IUserService> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<List<UserModel>> DeleteUserById(int id)
        {
            var deletedUser = GetUserById(id);

            _dataContext.Remove(deletedUser);
            await _dataContext.SaveChangesAsync();

            var users = GetAllUsers();

            return users;
        }

        public List<UserModel> GetAllUsers()
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

        public async Task<List<UserModel>> SetUser(SetUserDTO user)
        {

            var newUser = new UserModel()
            {
                UserName = user.UserName,
                Email = user.UserEmail
            };

            _dataContext.Users.Add(newUser);
            await _dataContext.SaveChangesAsync();

            var users = GetAllUsers();

            return users;
        }

        public async Task<List<UserModel>> UpdateUser(UpdateUserDTO user)
        {
            var newUser = GetUserById(user.UserId);

            if (newUser == null) return null;

            newUser.UserName = user.UserName;
            newUser.Email = user.UserEmail;

            _dataContext.Users.Update(newUser);
            await _dataContext.SaveChangesAsync();

            var users = GetAllUsers();

            return users;
        }
    }
}
