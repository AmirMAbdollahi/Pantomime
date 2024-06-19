using Pantomime.Entities;

namespace Pantomime.Services;

public interface IWordService
{
    public bool Add(string name, int categoryId);

    public List<Word> GetAll();

    public bool Update(int id, string name, int categoryId);

    public bool Delete(int id, bool isDeleted);
}