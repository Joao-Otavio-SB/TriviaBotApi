using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TriviaBotApi.DTO_s;
using TriviaBotApi.Models;
using TriviaBotApi.Services.AuthServices;

namespace TriviaBotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ResponseModel<UserModel>>> RegisterUser(RegisterUserDTO user)
        {
            var response = new ResponseModel<UserModel>();

            response.Status = 200;

            response.Content = await _authService.Register(user);

            return response;
        }
        
        [HttpPost("Login")]
        public async Task<ActionResult<ResponseModel<string>>> LoginUser(LoginUserDTO user)
        {
            var response = new ResponseModel<string>();

            response.Status = 200;

            response.Content = await _authService.Login(user.UserEmail, user.Password);

            return response;
        }
    }
}
