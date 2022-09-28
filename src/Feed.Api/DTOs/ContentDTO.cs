using System.ComponentModel.DataAnnotations;

namespace Feed.Api.DTOs
{
    public class ContentDTO
    {
        public ContentDTO()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }
    }
}
