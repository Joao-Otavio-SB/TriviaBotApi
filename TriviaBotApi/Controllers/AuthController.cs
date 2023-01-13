using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaBotApi.DTO_s;
using TriviaBotApi.Models;

namespace TriviaBotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ActionResult<ResponseModel> RegisterUser(RegisterUserDTO user)
        {
            return null;
        }
    }
}
