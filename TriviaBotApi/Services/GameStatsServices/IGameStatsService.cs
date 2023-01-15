using TriviaBotApi.DTO_s;
using TriviaBotApi.Models;

namespace TriviaBotApi.Services.GameStatsServices
{
    public interface IGameStatsService
    {
        public List<GameStats> GetGameStatsByUserId(int id);

        public Task<List<GameStats>> SetGameStats(SetGameStatsDTO gameStats);

        public Task<List<GameStats>> UpdateGameStats(UpdateGameStatsDTO gameStats);

        public Task<List<GameStats>> DeleteGameStatsByCategoryId(DeleteGameStatsDTO gameStats);
    }
}
