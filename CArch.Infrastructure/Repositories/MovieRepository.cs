using CArch.Core.Entities;
using CArch.Core.Repositories;
using CArch.Infrastructure.Data;
using CArch.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CArch.Infrastructure.Repositories
{
    public class MovieRepository:Repository<Movie>,IMovieRepository
    {
        public MovieRepository(CArchApplicationDbContext cArchApplicationDbContext):base(cArchApplicationDbContext)
        {

        }

        public async Task<IEnumerable<Movie>> GetMoviesWithGenre()
        {
            return await _cArchApplicationDbContext.Movies.Include(x => x.MovieGenres).ThenInclude(x=>x.Genre).ToListAsync();
        }
        public async Task<IEnumerable<Genre>> GetGenreAsync()
        {
            return await _cArchApplicationDbContext.Genres.ToListAsync();
        }
        public async Task<IEnumerable<MovieGenre>> GetMovieGenreAsync() {
            return await _cArchApplicationDbContext.MovieGenres.ToListAsync();
        }

    }
}
