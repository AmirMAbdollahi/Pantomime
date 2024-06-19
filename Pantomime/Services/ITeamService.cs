using Pantomime.Entities;

namespace Pantomime.Services;

public interface ITeamService
{
    public bool Add(string name);

    public List<Team> GetAll();

    public bool Update(int id, string name);

    public bool Delete(int id);
}