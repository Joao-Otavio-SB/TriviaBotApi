using System.Text.Json.Serialization;

namespace TriviaBotApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string UserName { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public List<GameStats> GameStats { get; set; } = null;
    }
}
