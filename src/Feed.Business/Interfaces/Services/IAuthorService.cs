using Feed.Business.Models;

namespace Feed.Business.Interfaces.Services;

public interface IAuthorService
{
    Task<Author> Add(Author author);
    Task Update(Author author);
    Task Remove(Guid id);

}
