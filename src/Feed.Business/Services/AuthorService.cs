using Feed.Business.Interfaces;
using Feed.Business.Interfaces.Repositories;
using Feed.Business.Interfaces.Services;
using Feed.Business.Models;

namespace Feed.Business.Services
{
    public class AuthorService : BaseService, IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository, INotifier notifier) : base(notifier)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author?> Add(Author author)
        {
            if (!ExecuteValidation(new AuthorValidation(), author))
                return null;

            await _authorRepository.Add(author);

            return author;
        }

        public async Task Remove(Guid id)
        {
             await _authorRepository.GetById(id);
        }

        public async Task Update(Author author)
        {
            if (!ExecuteValidation(new AuthorValidation(), author))
                return;

            await _authorRepository.Update(author);
        }

        public void Dispose()
        {
            _authorRepository?.Dispose();
        }
    }
}
