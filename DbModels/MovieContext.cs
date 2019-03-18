using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FwMovieApi.DbModels {
    public class MovieContext : DbContext {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
