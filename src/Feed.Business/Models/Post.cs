namespace Feed.Business.Models;

public class Post : Entity
{
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }
    public DateTime PublishedAt { get; set; }

    public IEnumerable<Content> Contents { get; set; }
}
