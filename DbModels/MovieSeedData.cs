using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FwMovieApi.DbModels {
    public static class MovieSeedData {
        public static void AddMovieSeedData(MovieContext context) {
            AddMovies(context);
            AddGenres(context);
        }
        public static void AddMovies(MovieContext context) {
            context.Movies.Add(new Movie {
                id = 1,
                runningTime = 117,
                title = "Blade Runner",
                yearOfRelease = 1982
            });
            context.Movies.Add(new Movie {
                id = 2,
                runningTime = 112,
                title = "Rear Window",
                yearOfRelease = 1954
            });
            context.Movies.Add(new Movie {
                id = 3,
                runningTime = 106,
                title = "Gattaca",
                yearOfRelease = 1997
            });
            context.Movies.Add(new Movie {
                id = 4,
                runningTime = 113,
                title = "Being John Malkovich",
                yearOfRelease = 1999
            });
            context.Movies.Add(new Movie {
                id = 5,
                runningTime = 108,
                title = "Eternal Sunshine of the Spotless Mind",
                yearOfRelease = 2004
            });
            context.Movies.Add(new Movie {
                id = 6,
                runningTime = 106,
                title = "Dunkirk",
                yearOfRelease = 2017
            });
            context.Movies.Add(new Movie {
                id = 7,
                runningTime = 106,
                title = "Can You Ever Forgive Me?",
                yearOfRelease = 2018
            });
            context.Movies.Add(new Movie {
                id = 8,
                runningTime = 207,
                title = "Seven Samurai",
                yearOfRelease = 1954
            });
            context.Movies.Add(new Movie {
                id = 9,
                runningTime = 125,
                title = "Spirited Away",
                yearOfRelease = 2001
            });
            context.Movies.Add(new Movie {
                id = 10,
                runningTime = 104,
                title = "Get Out",
                yearOfRelease = 2017
            });
            context.SaveChanges();
        }
        private static void AddGenres(MovieContext context) {
            context.Genres.Add(new Genre { id = 1, genreName = "Action" });
            context.Genres.Add(new Genre { id = 2, genreName = "Crime" });
            context.Genres.Add(new Genre { id = 3, genreName = "Fantasy" });
            context.Genres.Add(new Genre { id = 4, genreName = "Western" });
            context.Genres.Add(new Genre { id = 5, genreName = "Historical" });
            context.Genres.Add(new Genre { id = 6, genreName = "Romance" });
            context.Genres.Add(new Genre { id = 7, genreName = "Animation" });
            context.Genres.Add(new Genre { id = 8, genreName = "Horror" });
            context.Genres.Add(new Genre { id = 9, genreName = "Science Fiction" });
            context.SaveChanges();
        }
    }
}
