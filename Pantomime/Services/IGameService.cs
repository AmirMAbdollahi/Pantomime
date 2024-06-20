using Pantomime.Entities;

namespace Pantomime.Services;

public interface IGameService
{
    public bool Add(string title, byte totalRoundCount, bool isStarted);

    public List<Game> GetAll();

    public bool Update(int id, string title, byte totalRoundCount, bool isStarted);

    public bool Delete(int id);
}