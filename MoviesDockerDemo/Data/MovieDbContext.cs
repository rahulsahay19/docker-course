using Microsoft.EntityFrameworkCore;
using MoviesDockerDemo.Data.Models;

namespace MoviesDockerDemo.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
