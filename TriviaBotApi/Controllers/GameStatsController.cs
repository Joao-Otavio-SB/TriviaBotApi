using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TriviaBotApi.DTO_s;
using TriviaBotApi.Models;
using TriviaBotApi.Services.GameStatsServices;

namespace TriviaBotApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GameStatsController : ControllerBase
    {
        private readonly IGameStatsService _gameStatsService;

        public GameStatsController(IGameStatsService gameStatsService)
        {
            _gameStatsService = gameStatsService;
        }

        [HttpGet("get/{id}")]
        public ActionResult<ResponseModel<List<GameStats>>> GetGameStatsByUserId([FromRoute] int id)
        {
            var response = new ResponseModel<List<GameStats>>();

            response.Status = 200;

            response.Content = _gameStatsService.GetGameStatsByUserId(id);

            return response;
        }

        [HttpPost("add")]
        public async Task<ActionResult<ResponseModel<List<GameStats>>>> SetGameStats([FromBody] SetGameStatsDTO gameStats)
        {
            var response = new ResponseModel<List<GameStats>>();

            response.Status = 200;

            response.Content = await _gameStatsService.SetGameStats(gameStats);

            return response;
        }

        [HttpPost("update")]
        public async Task<ActionResult<ResponseModel<List<GameStats>>>> UpdateGameStats([FromBody] UpdateGameStatsDTO gameStats)
        {
            var response = new ResponseModel<List<GameStats>>();

            response.Status = 200;

            response.Content = await _gameStatsService.UpdateGameStats(gameStats);

            return response;
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<ResponseModel<List<GameStats>>>> DeleteGameStatsByCategoryId([FromBody] DeleteGameStatsDTO gameStats)
        {
            var response = new ResponseModel<List<GameStats>>();

            response.Status = 200;

            response.Content = await _gameStatsService.DeleteGameStatsByCategoryId(gameStats);

            return response;
        }
    }
}
