using Feed.Business.Models;

namespace Feed.Business.Interfaces.Repositories;

public interface IAuthorRepository : IRepository<Author>
{
    Task<Author> GetAuthorPosts(Guid id);
}
