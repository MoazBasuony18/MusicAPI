using System.Collections.Generic;

namespace MusicAPI.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public virtual IList<Album> Albums { get; set; }
    }
}
