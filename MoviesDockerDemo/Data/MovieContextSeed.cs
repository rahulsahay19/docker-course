using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesDockerDemo.Data.Models;

namespace MoviesDockerDemo.Data
{
    public class MovieContextSeed
    {
        public static async Task SeedAsync(MovieDbContext dbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                //dbContext.Database.Migrate();
                dbContext.Database.EnsureCreated();

                if (!dbContext.Movies.Any())
                {
                    dbContext.Movies.AddRange(GetPreconfiguredOrders());
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 5)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<MovieContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(dbContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }
        private static IEnumerable<Movie> GetPreconfiguredOrders()
        {
            return new List<Movie>()
            {
                new Movie
                {
                    DirectorName = "James Cameron",
                    Genre = "Action",
                    Name = "Avatar",
                    ReleaseYear = "2009"
                },
                new Movie
                {
                    DirectorName = "Lee Tamahori",
                    Genre = "Action, Suspense",
                    Name = "Die Another Day",
                    ReleaseYear = "2002"
                },
                new Movie
                {
                    DirectorName = "Gareth Edwards",
                    Genre = "Fiction, Science",
                    Name = "Godzilla",
                    ReleaseYear = "2014"
                },
                new Movie
                {
                    DirectorName = "Steven Spielberg",
                    Genre = "Fiction, Science",
                    Name = "Jurassic Park",
                    ReleaseYear = "1993"
                },
                new Movie
                {
                    DirectorName = "Brian De Palma",
                    Genre = "Thriller",
                    Name = "Mission Impossible",
                    ReleaseYear = "1996"
                }
            };
        }
    }
}
