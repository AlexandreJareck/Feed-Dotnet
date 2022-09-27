using Feed.Business.Interfaces;
using Feed.Business.Interfaces.Repositories;
using Feed.Business.Interfaces.Services;
using Feed.Business.Models;

namespace Feed.Business.Services
{
    public class PostService : BaseService, IPostService
    {
        private readonly IPostRepository _postRepository;
        

        public PostService(INotifier notifier,
                           IPostRepository postRepository) : base(notifier)
        {
            _postRepository = postRepository;
        }

        public async Task<Post?> Add(Post post)
        {   
            if (!ExecuteValidation(new PostValidation(), post))
                return null;
            
            await _postRepository.Add(post);

            return post;
        }

        public async Task<Post?> Update(Post post)
        {
            if (!ExecuteValidation(new PostValidation(), post))
                return null;

            await _postRepository.Update(post);

            return post;
        }

        public async Task Remove(Guid id)
        {
            await _postRepository.Remove(id);
        }

        public void Dispose()
        {
            _postRepository?.Dispose();
        }
    }
}
