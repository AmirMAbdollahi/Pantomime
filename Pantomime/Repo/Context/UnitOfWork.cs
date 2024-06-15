using Pantomime.DbContexts;
using Pantomime.Entities;

namespace Pantomime.Repo.Context;

public class UnitOfWork : IUnitOfWork
{
    private PantomimeDbContext _context;
    private IRepositories<Word> _wordRepo;
    private IRepositories<Category> _categoryRepo;
    private IRepositories<Game> _gameRepo;
    private IRepositories<Team> _teamRepo;
    private IRepositories<GameTeam> _gameTeamRepo;
    private IRepositories<GamePlay> _gamePlayRepo;

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

    public IRepositories<Category> CategoryRepo
    {
        get
        {
            if (_categoryRepo == null)
            {
                _categoryRepo = new Repositories<Category>(_context);
            }

            return _categoryRepo;
        }
    }

    public IRepositories<Game> GameRepo
    {
        get
        {
            if (_gameRepo == null)
            {
                _gameRepo = new Repositories<Game>(_context);
            }

            return _gameRepo;
        }
    }

    public IRepositories<Team> TeamRepo
    {
        get
        {
            if (_teamRepo == null)
            {
                _teamRepo = new Repositories<Team>(_context);
            }

            return _teamRepo;
        }
    }

    public IRepositories<GameTeam> GameTeamRepo
    {
        get
        {
            if (_gameTeamRepo == null)
            {
                _gameTeamRepo = new Repositories<GameTeam>(_context);
            }

            return _gameTeamRepo;
        }
    }

    public IRepositories<GamePlay> GamePlayRepo
    {
        get
        {
            if (_gamePlayRepo == null)
            {
                _gamePlayRepo = new Repositories<GamePlay>(_context);
            }

            return _gamePlayRepo;
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