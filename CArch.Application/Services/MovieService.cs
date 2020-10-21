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
            var movieEntity= await _movieRepository.GetAllAsync();
            var movieModel = movieEntity.Select(x => new MovieModel()
            {
                Name = x.Name
            });
            return movieModel;
        }
    }
}
