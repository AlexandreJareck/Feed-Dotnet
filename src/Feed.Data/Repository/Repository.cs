using Feed.Business.Interfaces.Repositories;
using Feed.Business.Models;
using Feed.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Feed.Data.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly FeedDbContext Db;
    protected readonly DbSet<TEntity> DbSet;

    public Repository(FeedDbContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }

    public virtual async Task<List<TEntity>> GetAll()
    {
        return await DbSet.ToListAsync();
    }
    public virtual async Task<TEntity> GetById(Guid id)
    {
        return await DbSet.FindAsync(id);
    }
    public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task Remove(Guid id)
    {
        DbSet.Remove(new TEntity { Id = id });
        await SaveChange();
    }
    public async Task Add(TEntity entity)
    {
        DbSet.Add(entity);
        await SaveChange();
    }
    public async Task Update(TEntity model)
    {
        DbSet.Update(model);
        await SaveChange();
    }

    public async Task<int> SaveChange()
    {
        return await Db.SaveChangesAsync();
    }

    public void Dispose()
    {
        Db?.Dispose();
    }
}
