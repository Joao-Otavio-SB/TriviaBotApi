using TriviaBotApi.Models;

namespace TriviaBotApi.DTO_s
{
    public class UpdateUserDTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }
    }
}
