using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesDockerDemo.Features.Movie.Models;

namespace MoviesDockerDemo.Features.Movie
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieListServiceModel>> GetMovies();
        Task<int> PostMovie(CreateMovieServiceModel movieListServiceModel);
    }
}
