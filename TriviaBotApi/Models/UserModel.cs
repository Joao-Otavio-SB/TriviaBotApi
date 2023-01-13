namespace TriviaBotApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public int GeneralRecord { get; set; }

        public GameStats[] GameStats { get; set; }
    }
}
