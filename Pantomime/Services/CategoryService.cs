using Pantomime.DbContexts;
using Pantomime.Entities;
using Pantomime.Repo.Context;

namespace Pantomime.Services;

public class CategoryService : ICategoryService
{
    public bool Add(string name)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        var isSuccessful = unit.CategoryRepo.Insert(new Category()
        {
            Name = name
        });
        unit.Save();
        return isSuccessful;
    }

    public List<Category> GetAll()
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        return unit.CategoryRepo.GetAll().ToList();
    }

    public bool Update(int id, string name)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        var isSuccessful = unit.CategoryRepo.Update(new Category()
        {
            Id = id,
            Name = name
        });
        unit.Save();
        return isSuccessful;
    }

    public bool Delete(int id)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        var isSuccessful = unit.CategoryRepo.Delete(id);
        unit.Save();
        return isSuccessful;
    }
}