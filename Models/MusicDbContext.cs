using Microsoft.EntityFrameworkCore;
using MusicAPI.Configurations.Entity;

namespace MusicAPI.Models
{
    public class MusicDbContext:DbContext
    {
        public MusicDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
        }
    }
}
