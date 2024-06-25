using Pantomime.DbContexts;
using Pantomime.DTO.GameDto;
using Pantomime.Entities;
using Pantomime.Repo;

namespace Pantomime.Services;

public class GameService : IGameService
{
    private readonly IRepositories<Game> _gameRepo;

    public GameService(IRepositories<Game> gameRepo)
    {
        _gameRepo = gameRepo;
    }

    public bool Add(CreateGameDto gameDto)
    {
        var game = new Game()
        {
            Title = gameDto.Title,
            TotalRoundCount = gameDto.TotalRoundCount,
            IsStarted = gameDto.IsStarted
        };
        var isSuccessful = _gameRepo.Insert(game);
        _gameRepo.Save();
        return isSuccessful;
    }

    public List<GameDto> GetAll()
    {
        var games = _gameRepo.GetAll().Select(game => new GameDto()
        {
            Id = game.Id,
            Title = game.Title,
            TotalRoundCount = game.TotalRoundCount,
            IsStarted = game.IsStarted
        }).ToList();
        return games;
    }

    public bool Update(UpdateGameDto gameDto)
    {
        var game = new Game()
        {
            Id = gameDto.Id,
            Title = gameDto.Title,
            TotalRoundCount = gameDto.TotalRoundCount,
            IsStarted = gameDto.IsStarted
        };
        var isSuccessful = _gameRepo.Update(game);
        _gameRepo.Save();
        return isSuccessful;
    }

    public bool Delete(int id)
    {
        return _gameRepo.Delete(id);
    }
}