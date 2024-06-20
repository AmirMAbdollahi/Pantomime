using Pantomime.DbContexts;
using Pantomime.Entities;
using Pantomime.Repo.Context;

namespace Pantomime.Services;

public class GameService:IGameService
{
    public bool Add(string title, byte totalRoundCount, bool isStarted)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        var isSuccessful = unit.GameRepo.Insert(new Game()
        {
            Title = title,
            TotalRoundCount = totalRoundCount,
            IsStarted = isStarted
        });
        unit.Save();
        return isSuccessful;
    }

    public List<Game> GetAll()
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        return unit.GameRepo.GetAll().ToList();
    }

    public bool Update(int id, string title, byte totalRoundCount, bool isStarted)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        var isSuccessful = unit.GameRepo.Update(new Game()
        {
            Id = id,
            Title = title,
            TotalRoundCount = totalRoundCount,
            IsStarted = isStarted
        });
        unit.Save();
        return isSuccessful;
    }

    public bool Delete(int id)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        return unit.GameRepo.Delete(id);
    }
}