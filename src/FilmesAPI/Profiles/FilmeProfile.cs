using AutoMapper;
using FilmesAPI.Models;
using FilmesAPI.Data.DTOs;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<Filme, ReadFilmeDTO>();
            CreateMap<CreateFilmeDTO, Filme>();
        }
    }
}