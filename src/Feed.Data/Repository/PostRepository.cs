using Feed.Business.Interfaces.Repositories;
using Feed.Business.Models;
using Feed.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Feed.Data.Repository;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(FeedDbContext context) : base(context)
    {

    }

    public async Task<Post> GetPostAuthor(Guid id)
    {
        return await Db
            .Posts
            .AsNoTracking()
            .Include(p => p.Author)
            .FirstOrDefaultAsync(p => p.Id == id) 
            ?? new Post();
    }

    public async Task<Post> GetPostAuthorContent(Guid id)
    {
        return await Db
            .Posts
            .AsNoTracking()
            .Include(p => p.Author)
            .Include(p => p.Contents)
            .FirstOrDefaultAsync(p => p.Id == id) 
            ?? new Post();
    }
}
