using System.ComponentModel.DataAnnotations;

namespace MoviesDockerDemo.Data.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string DirectorName { get; set; }
        public string ReleaseYear { get; set; }
        public string Genre { get; set; }


    }
}
