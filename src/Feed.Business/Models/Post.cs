using FluentValidation;

namespace Feed.Business.Models;

public class Post : Entity
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }

    public Author Author { get; set; }
    public DateTime PublishedAt { get; set; }

    public IEnumerable<Content>? Contents { get; set; }
}

public class PostValidation : AbstractValidator<Post>
{
    public PostValidation()
    {

    }
}