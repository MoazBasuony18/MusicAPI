using System.ComponentModel.DataAnnotations;

namespace MusicAPI.DTOs
{
    public class CreateAlbumDTO
    {
        [Required]
        public string AlbumName { get; set; }

        [Required]
        public DateTime DateReleased { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int ArtistId { get; set; }
    }
    public class UpdateAlbumDTO : CreateAlbumDTO
    {

    }
    public class AlbumDTO :CreateAlbumDTO
    {
        public int Id { get; set; }
        public GenreDTO Genre { get; set; }
        public ArtistDTO Artist { get; set; }

    }
}
