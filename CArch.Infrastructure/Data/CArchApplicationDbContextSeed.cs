using CArch.Core.Entities;
using CArch.Core.Enums;
using CArch.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
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
            await SeedLanguageAsync(cArchApplicationDbContext);
            await SeedMovieAsync(cArchApplicationDbContext);
            await SeedMovieGenreAsync(cArchApplicationDbContext);
            await SeedMovieLanguageAsync(cArchApplicationDbContext);
        }
        public static async Task SeedIdentityAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRolesAsync(userManager, roleManager);
            await SeedAdminAsync(userManager, roleManager);
            await SeedBasicUserAsync(userManager, roleManager);
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
        private static async Task SeedLanguageAsync(CArchApplicationDbContext cArchApplicationDbContext)
        {
            if (cArchApplicationDbContext.Languages.Any())
                return;

            var languages = new List<Language>()
            {
                new Language() { Name = "English"},
                new Language() { Name = "Hindi"},

            };

            cArchApplicationDbContext.Languages.AddRange(languages);
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
            var genreAction = cArchApplicationDbContext.Genres.FirstOrDefault(x => x.Name == "Action");
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
        private static async Task SeedMovieLanguageAsync(CArchApplicationDbContext cArchApplicationDbContext)
        {
            if (cArchApplicationDbContext.MovieLanguages.Any())
                return;
            var languageEnglish = cArchApplicationDbContext.Languages.FirstOrDefault(x => x.Name == "English");
            var languageHindi = cArchApplicationDbContext.Languages.FirstOrDefault(x => x.Name == "Hindi");
            var movieBatman = cArchApplicationDbContext.Movies.FirstOrDefault(x => x.Name == "Batman");
            var movieSuperman = cArchApplicationDbContext.Movies.FirstOrDefault(x => x.Name == "Superman");
            var movieLanguages = new List<MovieLanguage>()
            {
                new MovieLanguage() {Language=languageEnglish,LanguageId=languageEnglish.Id,Movie=movieBatman,MovieId=movieBatman.Id},
                new MovieLanguage() {Language=languageHindi,LanguageId=languageHindi.Id,Movie=movieBatman,MovieId=movieBatman.Id},
                new MovieLanguage() {Language=languageEnglish,LanguageId=languageEnglish.Id,Movie=movieSuperman,MovieId=movieSuperman.Id},
            };

            cArchApplicationDbContext.MovieLanguages.AddRange(movieLanguages);
            await cArchApplicationDbContext.SaveChangesAsync();
        }
        private static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
        private static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin",
                Email = "superadmin@localhost.com",
                FirstName = "pramod",
                LastName = "mishra",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "pr@mod");
                    //await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                    //await userManager.AddToRoleAsync(defaultUser, Roles.Moderator.ToString());
                    //await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                }

            }
        }
        private static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "pramod",
                Email = "pramod@localhost.com",
                FirstName = "dsfsd",
                LastName = "sdf",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()

            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "pr@mod");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }

            }
        }
    }
}
