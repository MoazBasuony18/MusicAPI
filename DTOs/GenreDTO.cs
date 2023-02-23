using MusicAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MusicAPI.DTOs
{
    public class CreateGenreDTO
    {
        [Required]
        public string GenreName { get; set; }
    }

    public class UpdateGenreDTO:CreateGenreDTO
    {
        public virtual IList<CreateAlbumDTO> Albums { get; set; }
    }
    public class GenreDTO:CreateGenreDTO
    {
        public int Id { get; set; }
        public virtual IList<AlbumDTO> Albums { get; set; }

    }
}
