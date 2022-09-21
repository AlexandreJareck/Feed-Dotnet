namespace Feed.Api.DTOs
{
    public class ContentDTO
    {
        public Guid PostId { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }

        public PostDTO Post { get; set; }
    }
}
