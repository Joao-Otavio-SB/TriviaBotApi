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
        public async Task<ActionResult<ResponseModel<UserModel>>> RegisterUser([FromBody] RegisterUserDTO user)
        {
            var response = new ResponseModel<UserModel>();

            response.Content = await _authService.Register(user);

            if (response.Content == null)
            {
                response.Status = 409;
                response.Message = "This e-mail is already registered!";
                return Conflict(response);
            }

            response.Status = 200;
            return Ok(response);
        }
        
        [HttpPost("Login")]
        public async Task<ActionResult<ResponseModel<string>>> LoginUser([FromBody] LoginUserDTO user)
        {
            var response = new ResponseModel<string>();

            response.Content = await _authService.Login(user.UserEmail, user.Password);

            if(response.Content == null)
            {
                response.Status = 409;
                response.Message = "The password or e-mail are wrong!";
                return Conflict(response);
            }

            response.Status = 200;
            return Ok(response);
        }

        [HttpGet("IsLogged")]
        public ActionResult<ResponseModel<bool>> IsLogged([FromHeader] string token)
        {
            var response = new ResponseModel<bool>();
            
            try
            {
                response.Content = _authService.IsUserLogged(token);
            }catch(Exception ex)
            {
                response.Status = 400;
                response.Message = "Not a valid token!";
                return BadRequest(response);
            }

            response.Status = 200;
            return Ok(response);
        }
    }
}
