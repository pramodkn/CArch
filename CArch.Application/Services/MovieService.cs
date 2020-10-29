using CArch.Application.Interfaces;
using CArch.Application.Models;
using CArch.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CArch.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<IEnumerable<MovieModel>> GetMovies()
        {
            var movieEntity= await _movieRepository.GetMovies();
            var movieModel = movieEntity.Select(x => new MovieModel()
            {
                Id = x.Id,
                Name = x.Name,
                MovieGenres = x.MovieGenres.Select(y => y.Genre.Name).ToArray(),
                MovieLanguages = x.MovieLanguages.Select(y => y.Language.Name).ToArray()
            });
            return movieModel;
        }
    }
}
