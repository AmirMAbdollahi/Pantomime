using Pantomime.DbContexts;
using Pantomime.Entities;
using Pantomime.Repo;

namespace Pantomime.Services;

public class WordService : IWordService
{
    private IRepositories<Word> _wordRepo;

    public WordService(IRepositories<Word> wordRepo)
    {
        _wordRepo = wordRepo;
    }

    public bool Add(string name, int categoryId)
    {
        var isSuccessful = _wordRepo.Insert(new Word()
        {
            Name = name,
            CategoryId = categoryId,
            IsDeleted = false,
        });
        _wordRepo.Save();
        return isSuccessful;
    }

    public List<Word> GetAll()
    {
        return _wordRepo.GetAll().ToList();
    }

    public bool Update(int id, string name, int categoryId)
    {
        var isSuccessful = _wordRepo.Update(new Word()
        {
            Id = id,
            Name = name,
            CategoryId = categoryId
        });
        _wordRepo.Save();
        return isSuccessful;
    }

    public bool Delete(int id, bool isDeleted)
    {
        var isSuccessful = _wordRepo.Delete(id);
        _wordRepo.Save();
        return isSuccessful;
    }
}