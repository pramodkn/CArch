using CArch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CArch.Infrastructure.Data
{
    public class CArchApplicationDbContextSeed
    {
        public static async Task SeedAsync(CArchApplicationDbContext cArchApplicationDbContext)
        {
            await SeedGenreAsync(cArchApplicationDbContext);
            await SeedMovieAsync(cArchApplicationDbContext);
            await SeedMovieGenreAsync(cArchApplicationDbContext);
        }
        private static async Task SeedGenreAsync(CArchApplicationDbContext cArchApplicationDbContext)
        {
            if (cArchApplicationDbContext.Genres.Any())
                return;

            var genres = new List<Genre>()
            {
                new Genre() { Name = "Action"},
                new Genre() { Name = "Thriller"},

            };

            cArchApplicationDbContext.Genres.AddRange(genres);
            await cArchApplicationDbContext.SaveChangesAsync();
        }
        private static async Task SeedMovieAsync(CArchApplicationDbContext cArchApplicationDbContext)
        {
            if (cArchApplicationDbContext.Movies.Any())
                return;

            var movies = new List<Movie>()
            {
                new Movie() { Name = "Batman"},
                new Movie() { Name = "Superman"}
            };

            cArchApplicationDbContext.Movies.AddRange(movies);
            await cArchApplicationDbContext.SaveChangesAsync();
        }
        private static async Task SeedMovieGenreAsync(CArchApplicationDbContext cArchApplicationDbContext)
        {
            if (cArchApplicationDbContext.MovieGenres.Any())
                return;
            var genreAction=cArchApplicationDbContext.Genres.FirstOrDefault(x => x.Name == "Action");
            var genreThriller = cArchApplicationDbContext.Genres.FirstOrDefault(x => x.Name == "Thriller");
            var movieBatman = cArchApplicationDbContext.Movies.FirstOrDefault(x => x.Name == "Batman");
            var movieSuperman = cArchApplicationDbContext.Movies.FirstOrDefault(x => x.Name == "Superman");

            var movieGenres = new List<MovieGenre>()
            {
                new MovieGenre() {Genre=genreAction,GenreId=genreAction.Id,Movie=movieBatman,MovieId=movieBatman.Id},
                new MovieGenre() {Genre=genreThriller,GenreId=genreThriller.Id,Movie=movieSuperman,MovieId=movieSuperman.Id},

            };

            cArchApplicationDbContext.MovieGenres.AddRange(movieGenres);
            await cArchApplicationDbContext.SaveChangesAsync();
        }
    }
}
