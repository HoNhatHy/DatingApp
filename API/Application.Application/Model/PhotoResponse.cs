namespace API.Application.Application.Model
{
    public class PhotoResponse
    {
        public int Id { get; set; }
        public string Url { get; set; } = "";
        public bool IsMain { get; set; }
        public string PublicId { get; set; } = "";
        public int UserId { get; set; }
    }
}
