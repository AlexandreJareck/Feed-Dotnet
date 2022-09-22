using Feed.Business.Interfaces.Services;
using Feed.Business.Models;

namespace Feed.Business.Services
{
    public class PostService : BaseService, IPostService
    {
        public Task Add(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
