using Pantomime.DbContexts;
using Pantomime.Entities;
using Pantomime.Repo.Context;

namespace Pantomime.Services;

public class GamePlayService : IGamePlayService
{
    public bool Add(byte round)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        var isSuccessful = unit.GamePlayRepo.Insert(new GamePlay()
        {
            Round = round
        });
        unit.Save();
        return isSuccessful;
    }

    public List<GamePlay> GetAll()
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        return unit.GamePlayRepo.GetAll().ToList();
    }

    public bool Update(int id, byte round)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        var isSuccessful = unit.GamePlayRepo.Update(new GamePlay()
        {
            Id = id,
            Round = round
        });
        unit.Save();
        return isSuccessful;
    }

    public bool Delete(int id)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        return unit.GamePlayRepo.Delete(id);
    }
}