using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesDockerDemo.Features.Movie.Models;

namespace MoviesDockerDemo.Features.Movie
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Method to list movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<MovieListServiceModel>> GetMovies()
        {
            return await _movieService.GetMovies();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> PostMovie(CreateMovieServiceModel movieServiceModel)
        {
            var id = await _movieService.PostMovie(movieServiceModel);
            return CreatedAtAction("PostMovie", id);
        }
    }
}
