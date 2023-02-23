using AutoMapper;
using MusicAPI.DTOs;
using MusicAPI.Models;

namespace MusicAPI.Configurations
{
    public class MapperInitlizer:Profile
    {
        public MapperInitlizer()
        {
            CreateMap<Artist, ArtistDTO>().ReverseMap();
            CreateMap<Artist, CreateArtistDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Genre, CreateGenreDTO>().ReverseMap(); 
            CreateMap<Album, AlbumDTO>().ReverseMap();
            CreateMap<Album, CreateAlbumDTO>().ReverseMap();
        }
    }
}
