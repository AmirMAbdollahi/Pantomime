using Pantomime.DbContexts;
using Pantomime.Entities;
using Pantomime.Repo;

namespace Pantomime.Services;

public class TeamService : ITeamService
{
    private readonly IRepositories<Team> _teamRepo;

    public TeamService(IRepositories<Team> teamRepo)
    {
        _teamRepo = teamRepo;
    }

    public bool Add(string name)
    {
        var isSuccessful = _teamRepo.Insert(new Team()
        {
            Name = name
        });
        _teamRepo.Save();
        return isSuccessful;
    }

    public List<Team> GetAll()
    {
        return _teamRepo.GetAll().ToList();
    }

    public bool Update(int id, string name)
    {
        var isSuccessful = _teamRepo.Update(new Team()
        {
            Id = id,
            Name = name,
        });
        _teamRepo.Save();
        return isSuccessful;
    }

    public bool Delete(int id)
    {
        var isSuccessful = _teamRepo.Delete(id);
        return isSuccessful;
    }
}