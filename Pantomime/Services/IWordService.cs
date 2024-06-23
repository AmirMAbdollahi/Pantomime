using Pantomime.DTO.WordDto;
using Pantomime.Entities;

namespace Pantomime.Services;

public interface IWordService
{
    public bool Add(string name, int categoryId);

    public List<WordDto> GetAll();

    public bool Update(int id, string name, int categoryId);

    public bool Delete(int id);
}