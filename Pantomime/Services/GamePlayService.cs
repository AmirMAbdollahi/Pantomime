using Pantomime.Entities;
using Pantomime.Repo;

namespace Pantomime.Services;

public class GamePlayService : IGamePlayService
{
    private readonly IRepositories<GamePlay> _gamePlay;

    public GamePlayService(IRepositories<GamePlay> gamePlay)
    {
        _gamePlay = gamePlay;
    }

    public bool Add(byte round)
    {
        var isSuccessful = _gamePlay.Insert(new GamePlay()
        {
            Round = round
        });
        _gamePlay.Save();
        return isSuccessful;
    }

    public List<GamePlay> GetAll()
    {
        return _gamePlay.GetAll().ToList();
    }

    public bool Update(int id, byte round)
    {
        var isSuccessful = _gamePlay.Update(new GamePlay()
        {
            Id = id,
            Round = round
        });
        _gamePlay.Save();
        return isSuccessful;
    }

    public bool Delete(int id)
    {
        return _gamePlay.Delete(id);
    }
}