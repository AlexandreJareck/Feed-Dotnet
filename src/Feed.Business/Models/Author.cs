namespace Feed.Business.Models;

public class Author : Entity
{
    public string AvatarUrl { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }

    public IEnumerable<Post> Posts { get; set; }
}