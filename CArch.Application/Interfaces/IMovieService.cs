using CArch.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CArch.Application.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieModel>> GetMovies();
    }
}
