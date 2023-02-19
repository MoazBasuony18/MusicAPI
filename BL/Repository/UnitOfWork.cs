using MusicAPI.BL.IRepository;
using MusicAPI.Models;

namespace MusicAPI.BL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MusicDbContext context;
        private IGenericRepository<Artist> artistRepository;
        private IGenericRepository<Genre> genreRepository;
        private IGenericRepository<Album> albumRepository;
        public UnitOfWork(MusicDbContext context)
        {
            this.context = context;
        }
        public IGenericRepository<Artist> Artists => artistRepository ?? new GenericRepository<Artist>(context);

        public IGenericRepository<Album> Albums => albumRepository ?? new GenericRepository<Album>(context);

        public IGenericRepository<Genre> Genres => genreRepository ?? new GenericRepository<Genre>(context); 

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync(); 
        }
    }
}
