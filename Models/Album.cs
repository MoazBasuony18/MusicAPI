using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public DateTime DateReleased { get; set; }

        [ForeignKey("GenreId")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [ForeignKey("ArtistId")]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
