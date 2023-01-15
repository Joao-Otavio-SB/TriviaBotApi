using System.Text.Json.Serialization;

namespace TriviaBotApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string UserName { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public List<GameStats> GameStats { get; set; } = null;
    }
}
