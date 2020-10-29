using System;
using System.Collections.Generic;
using System.Text;
using CArch.Core.Entities;
using CArch.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CArch.Infrastructure.Data
{
    public class CArchApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public CArchApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MovieLanguage> MovieLanguages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MovieGenre>(ConfigureMovieGenre);
            builder.Entity<MovieLanguage>(ConfigureMovieLanguage);
        }

        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey(mg => new { mg.GenreId, mg.MovieId });
            builder.HasOne(mg => mg.Movie)
                .WithMany(mg => mg.MovieGenres)
                .HasForeignKey(mg => mg.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(mg => mg.Genre)
                .WithMany(mg => mg.MovieGenres)
                .HasForeignKey(mg => mg.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

        }
        private void ConfigureMovieLanguage(EntityTypeBuilder<MovieLanguage> builder)
        {
            builder.HasKey(mg => new { mg.LanguageId, mg.MovieId });
            builder.HasOne(mg => mg.Movie)
                .WithMany(mg => mg.MovieLanguages)
                .HasForeignKey(mg => mg.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(mg => mg.Language)
                .WithMany(mg => mg.MovieLanguages)
                .HasForeignKey(mg => mg.LanguageId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
