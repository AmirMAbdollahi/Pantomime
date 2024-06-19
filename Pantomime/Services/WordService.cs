using Pantomime.DbContexts;
using Pantomime.Entities;
using Pantomime.Repo.Context;

namespace Pantomime.Services;

public class WordService : IWordService
{
    public bool Add(string name, int categoryId)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        var isSuccessful = unit.WordRepo.Insert(new Word()
        {
            Name = name,
            CategoryId = categoryId,
            IsDeleted = false,
        });
        unit.Save();
        return isSuccessful;
    }

    public List<Word> GetAll()
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        return unit.WordRepo.GetAll().ToList();
    }

    public bool Update(int id, string name, int categoryId)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        var isSuccessful = unit.WordRepo.Update(new Word()
        {
            Id = id,
            Name = name,
            CategoryId = categoryId
        });
        unit.Save();
        return isSuccessful;
    }

    public bool Delete(int id, bool isDeleted)
    {
        using var unit = new UnitOfWork(new PantomimeDbContext());
        var isSuccessful = unit.WordRepo.Delete(id);
        unit.Save();
        return isSuccessful;
    }
}