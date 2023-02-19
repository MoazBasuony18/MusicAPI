using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicAPI.Models;

namespace MusicAPI.Configurations.Entity
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasData(
                 new Artist
                 {
                     Id = 1,
                     ArtistName = "Amr Diab"
                 },
                new Artist
                {
                    Id = 2,
                    ArtistName = "Tamer Hosny"
                },
                new Artist
                {
                    Id = 3,
                    ArtistName = "Bahaa Sultan"
                },
                new Artist
                {
                    Id = 4,
                    ArtistName = "Tamer Ashour"
                });
        }
    }
}
