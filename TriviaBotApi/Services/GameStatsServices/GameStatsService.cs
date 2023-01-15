using Microsoft.EntityFrameworkCore;
using TriviaBotApi.Data;
using TriviaBotApi.DTO_s;
using TriviaBotApi.Models;

namespace TriviaBotApi.Services.GameStatsServices
{
    public class GameStatsService : IGameStatsService
    {
        private readonly DataContext _dataContext;

        public GameStatsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<GameStats>> DeleteGameStatsByCategoryId(DeleteGameStatsDTO gameStats)
        {
            var gameStatsList = GetGameStatsByUserId(gameStats.UserId);

            gameStatsList.ForEach(stat =>
            {
                if(stat.CategoryId == gameStats.CategoryId)
                {
                    _dataContext.Remove(stat);
                }
            });

            await _dataContext.SaveChangesAsync();

            return gameStatsList;
        }

        public List<GameStats> GetGameStatsByUserId(int id)
        {
            var gameStats = _dataContext.GameStats.Where(stat => stat.UserId == id).ToList();

            return gameStats;
        }

        public async Task<List<GameStats>> SetGameStats(SetGameStatsDTO gameStats)
        {

            var newUser = new GameStats()
            {
                UserId = gameStats.UserId,
                CategoryId = gameStats.CategoryId,
                CategoryName = gameStats.CategoryName,
                CategoryRecord = gameStats.CategoryRecord,
                GeneralRecord = gameStats.GeneralRecord,
                Losses = gameStats.Losses,
                Victories = gameStats.Victories,
                VLRatio = gameStats.VLRatio
            };

            _dataContext.Add(newUser);
            await _dataContext.SaveChangesAsync();

            var allStats = _dataContext.GameStats.Where(stat => stat.UserId == gameStats.UserId).ToList();

            return allStats;
        }

        public async Task<List<GameStats>> UpdateGameStats(UpdateGameStatsDTO gameStats)
        {
            var newGameStatsList = GetGameStatsByUserId(gameStats.UserId);

            newGameStatsList.ForEach(gameStat =>
            {
                if (gameStat.CategoryId == gameStats.CategoryId)
                {
                    gameStat.CategoryId = gameStats.CategoryId;
                    gameStat.CategoryName = gameStats.CategoryName;
                    gameStat.CategoryRecord = gameStats.CategoryRecord;
                    gameStat.GeneralRecord = gameStats.GeneralRecord;
                    gameStat.Losses = gameStats.Losses;
                    gameStat.Victories = gameStats.Victories;
                    gameStat.VLRatio = gameStats.VLRatio;

                    _dataContext.Update(gameStat);
                }
            });

            await _dataContext.SaveChangesAsync();

            return newGameStatsList;
        }
    }
}
