using Feed.Business.Interfaces.Repositories;
using Feed.Business.Models;
using Feed.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Feed.Data.Repository;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    public AuthorRepository(FeedDbContext context) : base(context)
    {

    }

    public async Task<Author> GetAuthorPosts(Guid id)
    {
        var result = await Db.Authors
            .AsNoTracking()
            .Include(a => a.Posts)!.ThenInclude(p => p.Contents)   
            .FirstOrDefaultAsync(a => a.Id == id)
            ?? new Author();

        return result;
    }
}
