using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicAPI.Models;

namespace MusicAPI.Configurations.Entity
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(
                new Genre
                {
                    Id = 1,
                    GenreName = "Romance"
                },
                new Genre 
                {
                    Id = 2,
                    GenreName = "Hip Hop"
                },
                new Genre
                {
                    Id=3,
                    GenreName="Classic"
                },
                new Genre
                {
                    Id = 4,
                    GenreName = "Rock"
                });
        }
    }
}
