using Feed.Business.Models;

namespace Feed.Business.Interfaces.Repositories;

public interface IContentRepository : IRepository<Content>
{
    Task<Content> GetContentByPost(Guid postId);
}
