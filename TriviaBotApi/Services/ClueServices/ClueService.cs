using RestEase;
using TriviaBotApi.Models;

namespace TriviaBotApi.Services.ClueServices
{
    public class ClueService : IClueService
    {
        public Task<ClueModel> GetRandomClueByCategory([Query] int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
