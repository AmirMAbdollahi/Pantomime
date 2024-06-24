using Pantomime.DTO.TeamDto;

namespace Pantomime.Services;

public interface ITeamService
{
    public bool Add(string name);

    public List<TeamDto> GetAll();

    public bool Update(UpdateTeamDto teamDto);

    public bool Delete(int id);
}