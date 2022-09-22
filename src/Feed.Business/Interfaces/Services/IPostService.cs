using Feed.Business.Models;

namespace Feed.Business.Interfaces.Services;

public interface IPostService
{
    Task Add(Post post);
    Task Update(Post post);
    Task Remove(Guid id);
}
