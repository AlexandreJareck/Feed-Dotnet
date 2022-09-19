using Feed.Business.Models;
using System.Linq.Expressions;

namespace Feed.Business.Interfaces.Repositories;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task Add(TEntity entity);
    Task<TEntity> GetById(Guid id);
    Task<List<TEntity>> GetAll();
    Task Update(TEntity model);
    Task Remove(Guid id);
    Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);
}
