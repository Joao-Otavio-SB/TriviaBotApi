using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaBotApi.DTO_s;
using TriviaBotApi.Models;
using TriviaBotApi.Services.UserServices;

namespace TriviaBotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get/{id}")]
        public ActionResult<ResponseModel<UserModel>> GetUserById([FromRoute] int id)
        {
            var user = _userService.GetUserById(id);
            var response = new ResponseModel<UserModel>();

            response.Status = 200;
            response.Content = user;

            return response;
        }

        [HttpGet("get")]
        public ActionResult<ResponseModel<List<UserModel>>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();

            var response = new ResponseModel<List<UserModel>>();

            response.Status = 200;
            response.Content = users;

            return response;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ResponseModel<UserModel>>> SetUser([FromBody] SetUserDTO user)
        {
            var response = new ResponseModel<UserModel>();

            response.Status = 200;

            response.Content = await _userService.SetUser(user);

            return response;
        }

        [HttpPost("update")]
        public async Task<ActionResult<ResponseModel<UserModel>>> UpdateUser([FromBody] UpdateUserDTO user)
        {
            var response = new ResponseModel<UserModel>();

            response.Status = 200;

            response.Content = await _userService.UpdateUser(user);

            return response;
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> DeleteUser([FromRoute] int id)
        {
            var response = new ResponseModel<List<UserModel>>();

            response.Status = 200;

            response.Content = await _userService.DeleteUserById(id);

            return response;
        }
    }
}
