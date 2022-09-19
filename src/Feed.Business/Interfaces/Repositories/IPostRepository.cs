using Feed.Business.Models;

namespace Feed.Business.Interfaces.Repositories;

public interface IPostRepository : IRepository<Post>
{
    Task<Post> GetPostAuthor(Guid id);
    Task<Post> GetPostAuthorContent(Guid id);
}
