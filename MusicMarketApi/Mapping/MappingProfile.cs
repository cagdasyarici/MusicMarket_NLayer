using AutoMapper;
using MusicMarket.Core.Model;
using MusicMarketApi.DTO;

namespace MusicMarketApi.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<Music,MusicDTO>().ReverseMap();
            CreateMap<Artist,ArtistDTO>();

            CreateMap<MusicDTO, Music>();
            CreateMap<ArtistDTO, Artist>();
            
            

            CreateMap<SaveMusicDTO,Music>();
            CreateMap<SaveArtistDTO,Artist>();
        }
    }
}
