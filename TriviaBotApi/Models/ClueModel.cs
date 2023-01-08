using System.Runtime.Serialization;

namespace TriviaBotApi.Models
{
    [DataContract(Name = "clues")]
    public class ClueModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "answer")]
        public string Answer { get; set; }

        [DataMember(Name = "question")]
        public string Question { get; set; }

        [DataMember(Name = "category_id")]
        public string CategoryId { get; set; }

        [DataMember(Name = "category")]
        public CategoryModel Category { get; set; }
    }
}
