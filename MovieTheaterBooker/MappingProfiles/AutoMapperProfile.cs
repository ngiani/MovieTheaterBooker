using AutoMapper;
using MovieTheaterBooker.Data;
using MovieTheaterBooker.Models;

namespace MovieTheaterBooker.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()  
        {
            CreateMap<Movie, MovieDetailsVM>();
            CreateMap<Screen, ScreenAtReleaseVM>();
        }
    }
}
