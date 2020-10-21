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
        public static async Task SeedAsync(CArchApplicationDbContext cArchApplicationDbContext) {
            await SeedMovieAsync(cArchApplicationDbContext);
        }

        private static async Task SeedMovieAsync(CArchApplicationDbContext cArchApplicationDbContext)
        {
            if (cArchApplicationDbContext.Movies.Any())
                return;

            var categories = new List<Movie>()
            {
                new Movie() { Name = "Batman"},
              
            };

            cArchApplicationDbContext.Movies.AddRange(categories);
            await cArchApplicationDbContext.SaveChangesAsync();
        }
    }
}
