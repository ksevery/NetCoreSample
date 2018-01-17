using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreSample.Models;

namespace NetCoreSample.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<DirectorsMovies> DirectorsMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Movie>().HasMany<DirectorsMovies>(u => u.DirectorsMovies);

            builder.Entity<DirectorsMovies>()
                .HasKey(f => new { f.DirectorId, f.MovieId });

            builder.Entity<DirectorsMovies>()
                .HasOne<Director>(f => f.Director)
                .WithMany(u => u.DirectorsMovies)
                .HasForeignKey(f => f.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<DirectorsMovies>()
                .HasOne<Movie>(f => f.Movie)
                .WithMany(u => u.DirectorsMovies)
                .HasForeignKey(f => f.DirectorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
