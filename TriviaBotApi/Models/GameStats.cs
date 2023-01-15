using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TriviaBotApi.Models
{
    public class GameStats
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public UserModel User { get; set; } = null;

        public string CategoryName { get; set; } = String.Empty;

        public int GeneralRecord { get; set; }

        public int CategoryRecord { get; set; }

        public int Victories { get; set; }

        public int Losses { get; set; }

        public float VLRatio { get; set; }
    }
}
