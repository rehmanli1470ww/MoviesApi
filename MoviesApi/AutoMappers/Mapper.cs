using AutoMapper;
using MoviesApi.Dtos;
using MoviesApi.Entities;

namespace MoviesApi.AutoMappers
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
        }
    }
}
