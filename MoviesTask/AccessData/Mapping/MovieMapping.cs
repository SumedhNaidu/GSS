using AccessData.Models;
using AutoMapper;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Mapping
{
    public class MovieMapping : Profile
    {
        public MovieMapping() 
        {
            CreateMap<Movies, MoviesDTO>();
            CreateMap<MoviesDTO, Movies>();
            CreateMap<Movies,CreateMoviesDTO>();
            CreateMap<CreateMoviesDTO, Movies>();
        }

    }
}
