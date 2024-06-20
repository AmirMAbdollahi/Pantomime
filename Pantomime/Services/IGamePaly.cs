using Pantomime.Entities;

namespace Pantomime.Services;

public interface IGamePlayService
{
    public bool Add(byte round);

    public List<GamePlay> GetAll();

    public bool Update(int id, byte round);

    public bool Delete(int id);

}