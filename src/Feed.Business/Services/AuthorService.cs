using Feed.Business.Interfaces.Services;
using Feed.Business.Models;

namespace Feed.Business.Services
{
    public class AuthorService : BaseService, IAuthorService
    {
        public Task Add(Author author)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
