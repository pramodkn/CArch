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
        public async Task<IEnumerable<MovieModel>> GetAllMovie()
        {
            var movieEntity= await _movieRepository.GetMoviesWithGenre();
            var movieModel = movieEntity.Select(x => new MovieModel()
            {
                Id = x.Id,
                Name = x.Name,
                MovieGenres = x.MovieGenres.Select(y => new MovieGenreModel() {
                    Name = y.Genre.Name,
                })
                
            });
            return movieModel;
        }
    }
}
