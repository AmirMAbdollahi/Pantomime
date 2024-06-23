using Pantomime.Entities;
using Pantomime.Repo;

namespace Pantomime.Services;

public class CategoryService : ICategoryService
{
    private IRepositories<Category> _categoryRepo;
    public CategoryService(IRepositories<Category> categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public bool Add(string name)
    {
        var isSuccessful = _categoryRepo.Insert(new Category()
        {
            Name = name
        });
        _categoryRepo.Save();
        return isSuccessful;
    }

    public List<Category> GetAll()
    {
        return _categoryRepo.GetAll().ToList();
    }

    public bool Update(int id, string name)
    {
        var isSuccessful = _categoryRepo.Update(new Category()
        {
            Id = id,
            Name = name
        });
        _categoryRepo.Save();
        return isSuccessful;
    }

    public bool Delete(int id)
    {
        var isSuccessful = _categoryRepo.Delete(id);
        _categoryRepo.Save();
        return isSuccessful;
    }
}