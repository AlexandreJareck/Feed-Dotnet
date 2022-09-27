using Feed.Business.Models;

namespace Feed.Business.Interfaces.Services;

public interface IPostService : IDisposable
{
    Task<Post?> Add(Post post);
    Task <Post?> Update(Post post);
    Task Remove(Guid id);
}
