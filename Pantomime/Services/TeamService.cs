using Pantomime.DbContexts;
using Pantomime.Entities;
using Pantomime.Repo.Context;

namespace Pantomime.Services;

public class TeamService : ITeamService
{
    public bool Add(string name)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        var isSuccessful = unit.TeamRepo.Insert(new Team()
        {
            Name = name
        });
        unit.Save();
        return isSuccessful;
    }

    public List<Team> GetAll()
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        return unit.TeamRepo.GetAll().ToList();
    }

    public bool Update(int id, string name)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        var isSuccessful = unit.TeamRepo.Update(new Team()
        {
            Id = id,
            Name = name,
        });
        unit.Save();
        return isSuccessful;
    }

    public bool Delete(int id)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        var isSuccessful = unit.TeamRepo.Delete(id);
        return isSuccessful;
    }
}