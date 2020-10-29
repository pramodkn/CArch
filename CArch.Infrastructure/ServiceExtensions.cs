using CArch.Core.Repositories;
using CArch.Infrastructure.Data;
using CArch.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CArch.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using CArch.Infrastructure.Interfaces;
using CArch.Infrastructure.Services;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

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

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<CArchApplicationDbContext>().AddDefaultTokenProviders();

            // Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = false;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:Audience"],
                    ValidIssuer = configuration["JWT:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                };
            });

            #region Services
            services.AddTransient<IAccountService, AccountService>();
            #endregion


            #region Repositories
            services.AddScoped<IMovieRepository, MovieRepository>();
            #endregion
        }
    }
}
