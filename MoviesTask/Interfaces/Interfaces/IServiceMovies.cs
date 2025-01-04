using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface IServiceMovies
    {
        public IList<MoviesDTO> FilterByTitle(string title);
        public IList<MoviesDTO> FilterByGenre(string genre);
        public ResponseDTO Addall(IList<CreateMoviesDTO> createMoviesDTO);
    }
}
