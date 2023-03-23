using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TriviaBotApi.Data;
using TriviaBotApi.DTO_s;
using TriviaBotApi.Models;
using TriviaBotApi.Services.UserServices;

namespace TriviaBotApi.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        public AuthService(IUserService userService, DataContext dataContext, IConfiguration configuration)
        {
            _userService = userService;
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<string> Login(string userEmail, string password)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == userEmail.ToLower());

            if (user == null) return "Incorrect password or e-mail!";
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return "Incorrect password or e-mail";

            return CreateToken(user);
        }

        public async Task<UserModel> Register(RegisterUserDTO user)
        {
            if (await UserAlreadyExists(user.UserEmail)) return null;

            CreatePasswordHash(user.UserPassword, out byte[] passwordHash, out byte[] passwordSalt);

            return await _userService.SetUser(user, passwordHash, passwordSalt);
        }

        public async Task<bool> UserAlreadyExists(string userEmail)
        {
            return await _dataContext.Users.AnyAsync(u => u.Email.ToLower() == userEmail.ToLower());
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(UserModel user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("ApiSettings:Token").Value));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
