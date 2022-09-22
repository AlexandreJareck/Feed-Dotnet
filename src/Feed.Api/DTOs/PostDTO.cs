using System.ComponentModel.DataAnnotations;

namespace Feed.Api.DTOs
{
    public class PostDTO
    {
        [Key]
        public Guid Id { get; set; }
        public AuthorDTO Author { get; set; }
        public DateTime PublishedAt { get; set; }

        public IEnumerable<ContentDTO> Contents { get; set; }
    }
}
