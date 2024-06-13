using Pantomime.DbContexts;
using Pantomime.Entities;

namespace Pantomime.Repo.Context;

public class UnitOfWork : IUnitOfWork
{
    private PantomimeDbContext _context;
    private IRepositories<Word> _wordRepo;

    public UnitOfWork(PantomimeDbContext context)
    {
        _context = context;
    }

    public IRepositories<Word> WordRepo
    {
        get
        {
            if (_wordRepo == null)
            {
                _wordRepo = new Repositories<Word>(_context);
            }

            return _wordRepo;
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}