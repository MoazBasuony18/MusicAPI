namespace MusicAPI.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public virtual IList<Album> Albums { get; set; }
    }
}
