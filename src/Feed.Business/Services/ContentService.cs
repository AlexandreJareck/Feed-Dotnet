using Feed.Business.Interfaces;
using Feed.Business.Interfaces.Services;
using Feed.Business.Models;

namespace Feed.Business.Services
{
    public class ContentService : BaseService, IContentService
    {
        public ContentService(INotifier notifier) : base(notifier)
        {

        }

        public Task Add(Content content)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Content content)
        {
            throw new NotImplementedException();
        }
    }
}
