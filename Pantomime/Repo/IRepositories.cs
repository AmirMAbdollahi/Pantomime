using System.Linq.Expressions;

namespace Pantomime.Repo;

public interface IRepositories<TEntity> where TEntity : class
{
    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null);

    TEntity GetById(object id);

    bool Insert(TEntity entity);

    bool Update(TEntity entity);

    bool Delete(object id);
}