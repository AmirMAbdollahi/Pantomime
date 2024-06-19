using Pantomime.Entities;

namespace Pantomime.Services;

public interface ICategoryService
{
    public bool Add(string name);

    public List<Category> Get();

    public bool Update(int id, string name);

    public bool Delete(int id);
}
