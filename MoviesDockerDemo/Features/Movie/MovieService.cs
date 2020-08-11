using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesDockerDemo.Data;
using MoviesDockerDemo.Features.Movie.Models;

namespace MoviesDockerDemo.Features.Movie
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _dbContext;
        private readonly IMapper _mapper;

        public MovieService(MovieDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieListServiceModel>> GetMovies()
        {
            var movies = await _dbContext.Movies.ToListAsync();
            return movies.Select(m => new MovieListServiceModel
            {
                Id = m.Id,
                DirectorName = m.DirectorName,
                Genre = m.Genre,
                Name = m.Name,
                ReleaseYear = m.ReleaseYear
            }).ToList();


        }

        public async Task<int> PostMovie(CreateMovieServiceModel movieServiceModel)
        {
            var movie = new Data.Models.Movie
            {
                DirectorName = movieServiceModel.DirectorName,
                Genre = movieServiceModel.Genre,
                Name = movieServiceModel.Name,
                ReleaseYear = movieServiceModel.ReleaseYear
            };

            _dbContext.Add(movie);
            await _dbContext.SaveChangesAsync();
            return movie.Id;
        }
    }
}
