using System.Runtime.Serialization;

namespace TriviaBotApi.Models
{
    public class ClueModel
    {
        public int Id { get; set; }

        public string Answer { get; set; }

        public string Question { get; set; }

        public string CategoryId { get; set; }

        public CategoryModel Category { get; set; }
    }
}
