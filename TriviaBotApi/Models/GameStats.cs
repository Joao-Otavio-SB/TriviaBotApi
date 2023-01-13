using System.ComponentModel.DataAnnotations;

namespace TriviaBotApi.Models
{
    public class GameStats
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int Record { get; set; }

        public int Victories { get; set; }

        public int Losses { get; set; }

        public float VLRatio { get; set; }
    }
}
