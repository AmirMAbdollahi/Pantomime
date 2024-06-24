using Pantomime.DTO.WordDto;
using Pantomime.Entities;

namespace Pantomime.Services;

public interface IWordService
{
    public bool Add(CreateWordDto wordDto);

    public List<WordDto> GetAll();

    public bool Update(UpdateWordDto wordDto);

    public bool Delete(int id);
}