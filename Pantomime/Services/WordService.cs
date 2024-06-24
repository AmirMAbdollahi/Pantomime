using Pantomime.DTO.WordDto;
using Pantomime.Entities;
using Pantomime.Repo;

namespace Pantomime.Services;

public class WordService : IWordService
{
    private readonly IRepositories<Word> _wordRepo;

    public WordService(IRepositories<Word> wordRepo)
    {
        _wordRepo = wordRepo;
    }

    public bool Add(CreateWordDto wordDto)
    {
        var word = new Word
        {
            Name = wordDto.Name,
            CategoryId = wordDto.CategoryId,
            IsDeleted = false
        };
        var isSuccessful = _wordRepo.Insert(word);
        _wordRepo.Save();
        return isSuccessful;
    }

    public List<WordDto> GetAll()
    {
        var words = _wordRepo.GetAll().Select(word => new WordDto()
        {
            Name = word.Name,
            CategoryName = word.Category.Name
        }).ToList();
        return words;
    }

    public bool Update(UpdateWordDto wordDto)
    {
        var word = new Word
        {
            Id = wordDto.Id,
            Name = wordDto.Name,
            CategoryId = wordDto.CategoryId
        };
        var isSuccessful = _wordRepo.Update(word);
        _wordRepo.Save();
        return isSuccessful;
    }

    public bool Delete(int id)
    {
        var isSuccessful = _wordRepo.Delete(id);
        _wordRepo.Save();
        return isSuccessful;
    }
}