using System.Collections.Generic;

namespace CArch.Application.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> MovieGenres { get; set; }
        public IEnumerable<string> MovieLanguages { get; set; }

    }
}