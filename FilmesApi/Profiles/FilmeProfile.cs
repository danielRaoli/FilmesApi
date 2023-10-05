﻿using AutoMapper;
using FilmesApi.Data.Dtos.FilmeDto;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<Filme, CreateFilmeDto>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme,UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>()
        .ForMember(cinemaDto => cinemaDto.Sessoes,
        opt => opt.MapFrom(cinema => cinema.Sessoes));
    }
}
