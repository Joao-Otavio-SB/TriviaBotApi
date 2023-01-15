namespace TriviaBotApi.Models
{
    public class ResponseModel<T>
    {
        public int Status { get; set; }

        public T Content { get; set; }
    }
}
