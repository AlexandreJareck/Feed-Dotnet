using Feed.Business.Interfaces.Repositories;
using Feed.Business.Models;
using Feed.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Feed.Data.Repository;

public class ContentRepository : Repository<Content>, IContentRepository
{
    public ContentRepository(FeedDbContext context) : base(context)
    {

    }

    public async Task<Content> GetContentByPost(Guid postId)
    {
        return await Db.Contents
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.PostId == postId)
            ?? new Content();
    }
}
