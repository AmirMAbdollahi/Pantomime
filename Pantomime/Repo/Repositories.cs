using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pantomime.DbContexts;
using Pantomime.Entities;

namespace Pantomime.Repo;

public class Repositories<TEntity> : IRepositories<TEntity> where TEntity : class
{
    private PantomimeDbContext _context;
    private DbSet<TEntity> _dbSet;

    public Repositories(PantomimeDbContext pantomimeDbContext)
    {
        this._context = pantomimeDbContext;
        _dbSet = _context.Set<TEntity>();
    }

    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> query = _dbSet.AsQueryable();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return query;
    }

    public TEntity GetById(object id)
    {
        return _dbSet.Find(id);
    }

    public bool Insert(TEntity entity)
    {
        try
        {
            _dbSet.Add(entity);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Update(TEntity entity)
    {
        try
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public bool Delete(object id)
    {
        var entity = GetById(id);
        if (entity is BaseEntity<int> deletedEntity)
        {
            deletedEntity.IsDeleted = true;
            return Update(entity);
        }
        _dbSet.Remove(entity);
        return false;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}