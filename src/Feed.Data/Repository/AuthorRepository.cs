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
        return await Db.Authors
            .AsNoTracking()
            .Include("Posts")   
            .Include("Posts.Contents")
            .FirstOrDefaultAsync(a => a.Id == id)
            ?? new Author();
    }
}
