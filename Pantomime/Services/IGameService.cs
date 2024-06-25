using Pantomime.DTO.GameDto;
using Pantomime.Entities;

namespace Pantomime.Services;

public interface IGameService
{
    public bool Add(CreateGameDto gameDto);

    public List<GameDto> GetAll();

    public bool Update(UpdateGameDto gameDto);

    public bool Delete(int id);
}