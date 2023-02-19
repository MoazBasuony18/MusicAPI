using System.ComponentModel.DataAnnotations;

namespace MusicAPI.DTOs
{
    public class CreateArtistDTO
    {
        [Required]
        public string ArtistName { get; set; }
    }

    public class UpdateArtistDTO : CreateArtistDTO
    {
        public virtual IList<AlbumDTO> Albums { get; set; }
    }
    public class ArtistDTO:CreateArtistDTO
    {
        public int Id { get; set; }
        public virtual IList<AlbumDTO> Albums { get; set; }
    }
}
