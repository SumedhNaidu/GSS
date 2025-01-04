using AccessData.Models;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface IRepositoryMovies
    {
        public IList<MoviesDTO> FilterByTitle(string title);
        public IList<MoviesDTO> FilterByGenre(string genre);
        public void Addall(IList<Movies> movie);
    }
}
