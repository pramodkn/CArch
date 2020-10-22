using System.Collections.Generic;

namespace CArch.Application.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MovieGenreModel> MovieGenres { get; set; }
    }
}