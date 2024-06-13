using Pantomime.Entities;

namespace Pantomime.Repo.Context;

public interface IUnitOfWork : IDisposable
{
    IRepositories<Word> WordRepo { get; }
    
    void Save();
}