using CArch.Core.Repositories;
using CArch.Infrastructure.Data;
using CArch.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CArch.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<CArchApplicationDbContext>(options =>
                options.UseInMemoryDatabase("CArchApplicationDbContext"));
            }
            else
            {
               services.AddDbContext<CArchApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(CArchApplicationDbContext).Assembly.FullName)));
            }
            #region Repositories
            services.AddScoped<IMovieRepository, MovieRepository>();
            #endregion
        }
    }
}
