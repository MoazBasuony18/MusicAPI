using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicAPI.Models;

namespace MusicAPI.Configurations.Entity
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasData(
                new Album
                {
                    Id = 1,
                    AlbumName="Album 1",
                    DateReleased=DateTime.Now.AddDays(-150),
                    ArtistId=1,
                    GenreId=2
                },
                new Album
                {
                    Id = 2,
                    AlbumName = "Album 2",
                    DateReleased = DateTime.Now.AddDays(-550),
                    ArtistId = 2,
                    GenreId = 2
                },
                new Album
                {
                    Id = 3,
                    AlbumName = "Album 3",
                    DateReleased = DateTime.Now.AddYears(-10),
                    ArtistId = 1,
                    GenreId = 3
                },
                new Album
                {
                    Id = 4,
                    AlbumName = "Album 4",
                    DateReleased = DateTime.Now.AddMonths(-90),
                    ArtistId = 3,
                    GenreId = 1
                }
                );
        }
    }
}
