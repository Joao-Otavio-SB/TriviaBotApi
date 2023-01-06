using RestEase;
using TriviaBotApi.Models;

namespace TriviaBotApi.Services.ClueServices
{
    public interface IClueService
    {
        [Get("/clues")]
        public Task<ClueModel> GetRandomClueByCategory([Query] int categoryId);
    }
}
