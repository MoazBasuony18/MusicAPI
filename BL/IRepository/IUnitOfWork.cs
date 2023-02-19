using MusicAPI.Models;

namespace MusicAPI.BL.IRepository
{
    public interface IUnitOfWork
    {
        IGenericRepository<Artist> Artists { get; }
        IGenericRepository<Album> Albums { get; }
        IGenericRepository<Genre> Genres{ get; }
        Task Save();

    }
}
