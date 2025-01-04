using Interfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace MoviesTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IServiceMovies _servicemovies;
        public MoviesController(IServiceMovies servicemovies)
        {
            _servicemovies = servicemovies;
        }
        [HttpGet]
        [Route("Filter By Title")]
        public ActionResult<IList<MoviesDTO>> FilterByTitle(string title)
        {
            var moviestitle = _servicemovies.FilterByTitle(title);
            return Ok(moviestitle);
        }
        [HttpGet]
        [Route("Filter By Genre")]
        public ActionResult<IList<MoviesDTO>> FilterByGenre(string genre)
        {
            var moviesgenre = _servicemovies.FilterByGenre(genre);
            return Ok(moviesgenre);
        }
        [HttpPost]
        public IActionResult AddAll([FromBody] IList<CreateMoviesDTO> createmovies)
        {
            var create = _servicemovies.Addall(createmovies);
            return (IActionResult)create;
        }
    }
}
