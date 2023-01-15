using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriviaBotApi.Models;
using TriviaBotApi.Services.ClueServices;

namespace TriviaBotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriviaController : ControllerBase
    {
        private readonly Constants constants = new Constants();
        private readonly IClueService _clueService;
        private readonly ILogger<TriviaController> _logger;

        public TriviaController(IClueService clueService, ILogger<TriviaController> logger)
        {
            _clueService = clueService;
            _logger = logger;
        }

        [HttpGet("clue")]
        public async Task<ActionResult<ResponseModel<ClueModel>>> GetClueByCategoryId([FromQuery] string category)
        {
            category = category.ToLower();
            var response = new ResponseModel<ClueModel>();

            int categoryId = SelectCategoryId(category);

            try
            {
                var clues = await _clueService.GetRandomClueByCategory(categoryId);

                var randomClue = GetRandomClue(clues);

                response.Status = 200;
                response.Content = randomClue;

                return Ok(response);
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        private int SelectCategoryId(string category)
        {
            int id;

            switch (category)
            {
                case "foods":
                    id = constants.FOOD_CATEGORY_ID;
                    break;
                case "movies":
                    id = constants.MOVIES_CATEGORY_ID;
                    break;
                case "sports":
                    id = constants.SPORTS_CATEGORY_ID;
                    break;
                case "astronomy":
                    id = constants.ASTRONOMY_CATEGORY_ID;
                    break;
                case "easy math":
                    id = constants.MATH_CATEGORY_ID;
                    break;
                case "video games":
                    id = constants.VIDEOGAMES_CATEGORY_ID;
                    break;
                default:
                    id = constants.VIDEOGAMES_CATEGORY_ID;
                    break;
            }

            return id;
        }

        private ClueModel GetRandomClue(ClueModel[] clues)
        {
            var random = new Random();

            var randomValue = random.Next(clues.Length);

            var clue = clues[randomValue];

            return clue;
        }

    }
}
