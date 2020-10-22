using CArch.Core.Entities;
using CArch.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CArch.Core.Repositories
{
    public interface IMovieRepository :IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesWithGenre();
        Task<IEnumerable<Genre>> GetGenreAsync();
        Task<IEnumerable<MovieGenre>> GetMovieGenreAsync();
    }
}
