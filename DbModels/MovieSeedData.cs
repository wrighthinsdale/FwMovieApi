using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FwMovieApi.DbModels {
    public static class MovieSeedData {
        public static void AddMovieSeedData(MovieContext context) {
            AddMovies(context);
            AddGenres(context);
            AddMovieGenres(context);
            AddRatings(context);
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
            context.Movies.Add(new Movie {
                id = 11,
                runningTime = 143,
                title = "Skyfall",
                yearOfRelease = 2012
            });
            context.Movies.Add(new Movie {
                id = 12,
                runningTime = 104,
                title = "Silver Linings Playbook",
                yearOfRelease = 2012
            });
            context.Movies.Add(new Movie {
                id = 13,
                runningTime = 99,
                title = "Shaun of the Dead",
                yearOfRelease = 2004
            });
            context.Movies.Add(new Movie {
                id = 14,
                runningTime = 116,
                title = "The Nice Guys",
                yearOfRelease = 2016
            });
            context.Movies.Add(new Movie {
                id = 15,
                runningTime = 103,
                title = "10 Cloverfield Lane",
                yearOfRelease = 2016
            });
            context.Movies.Add(new Movie {
                id = 16,
                runningTime = 127,
                title = "Hereditary",
                yearOfRelease = 2018
            });
            context.Movies.Add(new Movie {
                id = 17,
                runningTime = 117,
                title = "A Simple Favor",
                yearOfRelease = 2018
            });
            context.Movies.Add(new Movie {
                id = 18,
                runningTime = 164,
                title = "The Dark Knight Rises",
                yearOfRelease = 2012
            });
            context.Movies.Add(new Movie {
                id = 19,
                runningTime = 120,
                title = "Argo",
                yearOfRelease = 2012
            });
            context.Movies.Add(new Movie {
                id = 20,
                runningTime = 150,
                title = "Lincoln",
                yearOfRelease = 2012
            });
            context.SaveChanges();
        }
        private static void AddGenres(MovieContext context) {
            context.Genres.Add(new Genre { id = 1, genreName = "Action" });
            context.Genres.Add(new Genre { id = 2, genreName = "Thriller" });
            context.Genres.Add(new Genre { id = 3, genreName = "Drama" });
            context.Genres.Add(new Genre { id = 4, genreName = "Western" });
            context.Genres.Add(new Genre { id = 5, genreName = "Historical" });
            context.Genres.Add(new Genre { id = 6, genreName = "Romance" });
            context.Genres.Add(new Genre { id = 7, genreName = "Animation" });
            context.Genres.Add(new Genre { id = 8, genreName = "Horror" });
            context.Genres.Add(new Genre { id = 9, genreName = "Science Fiction" });
            context.Genres.Add(new Genre { id = 10, genreName = "Comedy" });
            context.SaveChanges();
        }
        private static void AddMovieGenres(MovieContext context) {
            context.MovieGenres.Add(new MovieGenre { id = 1, movieId = 1, genreId = 9 });
            context.MovieGenres.Add(new MovieGenre { id = 2, movieId = 2, genreId = 2 });
            context.MovieGenres.Add(new MovieGenre { id = 3, movieId = 3, genreId = 9 });
            context.MovieGenres.Add(new MovieGenre { id = 4, movieId = 4, genreId = 9 });
            context.MovieGenres.Add(new MovieGenre { id = 5, movieId = 5, genreId = 9 });
            context.MovieGenres.Add(new MovieGenre { id = 6, movieId = 6, genreId = 5 });
            context.MovieGenres.Add(new MovieGenre { id = 7, movieId = 7, genreId = 3 });
            context.MovieGenres.Add(new MovieGenre { id = 8, movieId = 8, genreId = 1 });
            context.MovieGenres.Add(new MovieGenre { id = 9, movieId = 9, genreId = 7 });
            context.MovieGenres.Add(new MovieGenre { id = 10, movieId = 10, genreId = 8 });
            context.MovieGenres.Add(new MovieGenre { id = 11, movieId = 11, genreId = 1 });
            context.MovieGenres.Add(new MovieGenre { id = 12, movieId = 12, genreId = 3 });
            context.MovieGenres.Add(new MovieGenre { id = 13, movieId = 13, genreId = 8 });
            context.MovieGenres.Add(new MovieGenre { id = 14, movieId = 14, genreId = 1 });
            context.MovieGenres.Add(new MovieGenre { id = 15, movieId = 15, genreId = 2 });
            context.MovieGenres.Add(new MovieGenre { id = 16, movieId = 16, genreId = 2 });
            context.MovieGenres.Add(new MovieGenre { id = 17, movieId = 17, genreId = 3 });
            context.MovieGenres.Add(new MovieGenre { id = 18, movieId = 18, genreId = 1 });
            context.MovieGenres.Add(new MovieGenre { id = 19, movieId = 19, genreId = 2 });
            context.MovieGenres.Add(new MovieGenre { id = 20, movieId = 20, genreId = 3 });
            context.MovieGenres.Add(new MovieGenre { id = 21, movieId = 4, genreId = 10 });
            context.MovieGenres.Add(new MovieGenre { id = 22, movieId = 5, genreId = 6 });
            context.MovieGenres.Add(new MovieGenre { id = 23, movieId = 7, genreId = 5 });
            context.MovieGenres.Add(new MovieGenre { id = 24, movieId = 8, genreId = 5 });
            context.MovieGenres.Add(new MovieGenre { id = 25, movieId = 11, genreId = 2 });
            context.MovieGenres.Add(new MovieGenre { id = 26, movieId = 12, genreId = 6 });
            context.MovieGenres.Add(new MovieGenre { id = 27, movieId = 12, genreId = 10 });
            context.MovieGenres.Add(new MovieGenre { id = 28, movieId = 13, genreId = 10 });
            context.MovieGenres.Add(new MovieGenre { id = 29, movieId = 14, genreId = 2 });
            context.MovieGenres.Add(new MovieGenre { id = 30, movieId = 14, genreId = 10 });
            context.MovieGenres.Add(new MovieGenre { id = 31, movieId = 15, genreId = 9 });
            context.MovieGenres.Add(new MovieGenre { id = 32, movieId = 16, genreId = 3 });
            context.MovieGenres.Add(new MovieGenre { id = 33, movieId = 16, genreId = 8 });
            context.MovieGenres.Add(new MovieGenre { id = 34, movieId = 17, genreId = 10 });
            context.MovieGenres.Add(new MovieGenre { id = 35, movieId = 18, genreId = 2 });
            context.MovieGenres.Add(new MovieGenre { id = 36, movieId = 19, genreId = 3 });
            context.MovieGenres.Add(new MovieGenre { id = 37, movieId = 20, genreId = 5 });
            //context.MovieGenres.Add(new MovieGenre { id = 38, movieId = 20, genreId = 5 });
            context.SaveChanges();
        }
        private static void AddRatings(MovieContext context) {
            context.Ratings.Add(new Rating { id = 1, userId = 1, movieId = 1, rating = 5 });
            context.Ratings.Add(new Rating { id = 2, userId = 1, movieId = 2, rating = 5 });
            context.Ratings.Add(new Rating { id = 3, userId = 1, movieId = 3, rating = 3 });
            context.Ratings.Add(new Rating { id = 4, userId = 1, movieId = 4, rating = 2 });
            context.Ratings.Add(new Rating { id = 5, userId = 1, movieId = 5, rating = 1 });
            context.Ratings.Add(new Rating { id = 6, userId = 1, movieId = 6, rating = 4 });
            context.Ratings.Add(new Rating { id = 7, userId = 1, movieId = 7, rating = 5 });
            context.Ratings.Add(new Rating { id = 8, userId = 1, movieId = 8, rating = 3 });
            context.Ratings.Add(new Rating { id = 9, userId = 1, movieId = 9, rating = 1 });
            context.Ratings.Add(new Rating { id = 10, userId = 1, movieId = 10, rating = 4 });
            context.Ratings.Add(new Rating { id = 11, userId = 1, movieId = 11, rating = 1 });
            context.Ratings.Add(new Rating { id = 12, userId = 1, movieId = 12, rating = 2 });
            context.Ratings.Add(new Rating { id = 13, userId = 1, movieId = 13, rating = 3 });
            context.Ratings.Add(new Rating { id = 14, userId = 1, movieId = 14,  rating =  4 });
            context.Ratings.Add(new Rating { id = 15, userId = 1, movieId = 15,  rating =  5 });
            context.Ratings.Add(new Rating { id = 16, userId = 1, movieId = 16,  rating =  1 });
            context.Ratings.Add(new Rating { id = 17, userId = 1, movieId = 17,  rating =  1 });
            context.Ratings.Add(new Rating { id = 18, userId = 1, movieId = 18,  rating =  2 });
            context.Ratings.Add(new Rating { id = 19, userId = 1, movieId = 19,  rating =  2 });
            context.Ratings.Add(new Rating { id = 20, userId = 1, movieId = 20,  rating =  3 });
            context.Ratings.Add(new Rating { id = 21, userId = 2, movieId = 1,  rating =  5 });
            context.Ratings.Add(new Rating { id = 22, userId = 2, movieId = 2,  rating =  5 });
            context.Ratings.Add(new Rating { id = 23, userId = 2, movieId = 3,  rating =  5 });
            context.Ratings.Add(new Rating { id = 24, userId = 2, movieId = 4,  rating =  5 });
            context.Ratings.Add(new Rating { id = 25, userId = 2, movieId = 5,  rating =  5 });
            context.Ratings.Add(new Rating { id = 26, userId = 2, movieId = 6,  rating =  5 });
            context.Ratings.Add(new Rating { id = 27, userId = 2, movieId = 7,  rating =  5 });
            context.Ratings.Add(new Rating { id = 28, userId = 2, movieId = 8,  rating =  4 });
            context.Ratings.Add(new Rating { id = 29, userId = 2, movieId = 9,  rating =  4 });
            context.Ratings.Add(new Rating { id = 30, userId = 2, movieId = 10,  rating =  4 });
            context.Ratings.Add(new Rating { id = 31, userId = 2, movieId = 11,  rating =  4 });
            context.Ratings.Add(new Rating { id = 32, userId = 2, movieId = 12,  rating =  3 });
            context.Ratings.Add(new Rating { id = 33, userId = 2, movieId = 13,  rating =  3 });
            context.Ratings.Add(new Rating { id = 34, userId = 2, movieId = 14,  rating =  4 });
            context.Ratings.Add(new Rating { id = 35, userId = 2, movieId = 15,  rating =  5 });
            context.Ratings.Add(new Rating { id = 36, userId = 2, movieId = 16,  rating =  4 });
            context.Ratings.Add(new Rating { id = 37, userId = 2, movieId = 17,  rating =  4 });
            context.Ratings.Add(new Rating { id = 38, userId = 2, movieId = 18,  rating =  4 });
            context.Ratings.Add(new Rating { id = 39, userId = 2, movieId = 19,  rating =  1 });
            context.Ratings.Add(new Rating { id = 40, userId = 2, movieId = 20,  rating =  5 });
            context.Ratings.Add(new Rating { id = 41, userId = 3, movieId = 1,  rating =  5 });
            context.Ratings.Add(new Rating { id = 42, userId = 3, movieId = 2,  rating =  5 });
            context.Ratings.Add(new Rating { id = 43, userId = 3, movieId = 3,  rating =  1 });
            context.Ratings.Add(new Rating { id = 44, userId = 3, movieId = 4,  rating =  1 });
            context.Ratings.Add(new Rating { id = 45, userId = 3, movieId = 5,  rating =  2 });
            context.Ratings.Add(new Rating { id = 46, userId = 3, movieId = 6,  rating =  1 });
            context.Ratings.Add(new Rating { id = 47, userId = 3, movieId = 7,  rating =  5 });
            context.Ratings.Add(new Rating { id = 48, userId = 3, movieId = 8,  rating =  4 });
            context.Ratings.Add(new Rating { id = 49, userId = 3, movieId = 9,  rating =  2 });
            context.Ratings.Add(new Rating { id = 50, userId = 3, movieId = 10,  rating =  1 });
            context.Ratings.Add(new Rating { id = 51, userId = 3, movieId = 11,  rating =  2 });
            context.Ratings.Add(new Rating { id = 52, userId = 3, movieId = 12,  rating =  3 });
            context.Ratings.Add(new Rating { id = 53, userId = 3, movieId = 13,  rating =  1 });
            context.Ratings.Add(new Rating { id = 54, userId = 3, movieId = 14,  rating =  2 });
            context.Ratings.Add(new Rating { id = 55, userId = 3, movieId = 15,  rating =  1 });
            context.Ratings.Add(new Rating { id = 56, userId = 3, movieId = 16,  rating =  2 });
            context.Ratings.Add(new Rating { id = 57, userId = 3, movieId = 17,  rating =  3 });
            context.Ratings.Add(new Rating { id = 58, userId = 3, movieId = 18,  rating =  1 });
            context.Ratings.Add(new Rating { id = 59, userId = 3, movieId = 19,  rating =  5 });
            context.Ratings.Add(new Rating { id = 60, userId = 3, movieId = 20,  rating =  5 });
            context.Ratings.Add(new Rating { id = 61, userId = 4, movieId = 1,  rating =  5 });
            context.Ratings.Add(new Rating { id = 62, userId = 4, movieId = 2,  rating =  5 });
            context.Ratings.Add(new Rating { id = 63, userId = 4, movieId = 3,  rating =  2 });
            context.Ratings.Add(new Rating { id = 64, userId = 4, movieId = 4,  rating =  3 });
            context.Ratings.Add(new Rating { id = 65, userId = 4, movieId = 5,  rating =  5 });
            context.Ratings.Add(new Rating { id = 66, userId = 4, movieId = 6,  rating =  5 });
            context.Ratings.Add(new Rating { id = 67, userId = 4, movieId = 7,  rating =  1 });
            context.Ratings.Add(new Rating { id = 68, userId = 4, movieId = 8,  rating =  2 });
            context.Ratings.Add(new Rating { id = 69, userId = 4, movieId = 9,  rating =  3 });
            context.Ratings.Add(new Rating { id = 70, userId = 4, movieId = 10,  rating =  4 });
            context.Ratings.Add(new Rating { id = 71, userId = 4, movieId = 11,  rating =  3 });
            context.Ratings.Add(new Rating { id = 72, userId = 4, movieId = 12,  rating =  2 });
            context.Ratings.Add(new Rating { id = 73, userId = 4, movieId = 13,  rating =  1 });
            context.Ratings.Add(new Rating { id = 74, userId = 4, movieId = 14,  rating =  3 });
            context.Ratings.Add(new Rating { id = 75, userId = 4, movieId = 15,  rating =  5 });
            context.Ratings.Add(new Rating { id = 76, userId = 4, movieId = 16,  rating =  5 });
            context.Ratings.Add(new Rating { id = 77, userId = 4, movieId = 17,  rating =  5 });
            context.Ratings.Add(new Rating { id = 78, userId = 4, movieId = 18,  rating =  5 });
            context.Ratings.Add(new Rating { id = 79, userId = 4, movieId = 19,  rating =  5 });
            context.Ratings.Add(new Rating { id = 80, userId = 4, movieId = 20,  rating =  5 });
            context.SaveChanges();
        }
    }
}
