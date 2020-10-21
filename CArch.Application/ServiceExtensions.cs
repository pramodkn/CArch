using CArch.Application.Interfaces;
using CArch.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CArch.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services) {
            services.AddScoped<IMovieService, MovieService>();
        }
    }
}
