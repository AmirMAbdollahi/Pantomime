using Pantomime.DbContexts;
using Pantomime.Entities;
using Pantomime.Repo;

namespace Pantomime.Services;

public class GameService : IGameService
{
    private IRepositories<Game> _gameRepo;

    public GameService(IRepositories<Game> gameRepo)
    {
        _gameRepo = gameRepo;
    }

    public bool Add(string title, byte totalRoundCount, bool isStarted)
    {
        var isSuccessful = _gameRepo.Insert(new Game()
        {
            Title = title,
            TotalRoundCount = totalRoundCount,
            IsStarted = isStarted
        });
        _gameRepo.Save();
        return isSuccessful;
    }

    public List<Game> GetAll()
    {
        return _gameRepo.GetAll().ToList();
    }

    public bool Update(int id, string title, byte totalRoundCount, bool isStarted)
    {
        var isSuccessful = _gameRepo.Update(new Game()
        {
            Id = id,
            Title = title,
            TotalRoundCount = totalRoundCount,
            IsStarted = isStarted
        });
        _gameRepo.Save();
        return isSuccessful;
    }

    public bool Delete(int id)
    {
        return _gameRepo.Delete(id);
    }
}