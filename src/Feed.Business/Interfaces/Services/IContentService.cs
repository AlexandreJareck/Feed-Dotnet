using Feed.Business.Models;

namespace Feed.Business.Interfaces.Services;

public interface IContentService
{
    Task Add(Content content);
    Task Update(Content content);
    Task Remove(Guid id);
}
