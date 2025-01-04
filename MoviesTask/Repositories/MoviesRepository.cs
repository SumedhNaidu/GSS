using AccessData.Context;
using AccessData.Models;
using AutoMapper;
using Interfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MoviesRepository : IRepositoryMovies
    {
        private readonly MoviesDbContext _context;
        private readonly IMapper _mapper;
        public MoviesRepository(MoviesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Addall(IList<Movies> movie)
        {
            _context.movies.AddRange(movie);
            _context.SaveChanges();
        }

        public IList<MoviesDTO> FilterByGenre(string genre)
        {
            var genres = _context.movies.Where(m => m.Generes.ToLower().Contains(genre));
            var genreDto = _mapper.Map<IList<MoviesDTO>>(genres);
            return genreDto;
        }

        public IList<MoviesDTO> FilterByTitle(string title)
        {
            var titles = _context.movies.FirstOrDefault(m => m.Title == title);
            var titlesDto = _mapper.Map<IList<MoviesDTO>>(titles);
            return titlesDto;
        }
    }
}
