namespace TriviaBotApi.Models
{
    public class ResponseModel<T>
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public T Content { get; set; }
    }
}
