using Pantomime.DTO.TeamDto;
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
        var team = new Team()
        {
            Name = name,
            IsDeleted = false
        };
        var isSuccessful = _teamRepo.Insert(team);
        _teamRepo.Save();
        return isSuccessful;
    }

    public List<TeamDto> GetAll()
    {
        var teams = _teamRepo.GetAll().Select(team => new TeamDto()
        {
            Name = team.Name,
        }).ToList();
        return teams;
    }

    public bool Update(UpdateTeamDto teamDto)
    {
        var team = new Team()
        {
            Id = teamDto.Id,
            Name = teamDto.Name
        };
        var isSuccessful = _teamRepo.Update(team);
        _teamRepo.Save();
        return isSuccessful;
    }

    public bool Delete(int id)
    {
        var isSuccessful = _teamRepo.Delete(id);
        return isSuccessful;
    }
}