namespace TriviaBotApi.DTO_s
{
    public class UpdateGameStatsDTO
    {
        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = String.Empty;

        public int GeneralRecord { get; set; }

        public int CategoryRecord { get; set; }

        public int Victories { get; set; }

        public int Losses { get; set; }

        public float VLRatio { get; set; }
    }
}
