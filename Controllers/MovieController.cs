using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FwMovieApi.DbModels;
using FwMovieApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FwMovieApi.Controllers {
    //[Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase {
        private readonly MovieContext _context;
        private static List<string> _badMovieTitleList = (new string[] { "a", "an", "and", "the", "or" }).ToList();
        public MovieController(MovieContext context) {
            _context = context;
        }
        /// <summary>
        /// Search the in-memory database using a combination of title, yearOfRelease and genre values. 
        /// </summary>
        /// <remarks><b>title</b> is case-insensitve. Values must be longer than one letter in length, and simple words (a, an, and, the, or) are not allowed.
        /// <b>yearOfRelease</b> must be a four-digit integer greater than 1900, and less than 2050.
        /// <b>genres</b> are entered in a single comma-separated list (case-insensitive). Any genre entered this way will be returned (so, entering 'Comedy,Drama' will return all movies that are either comedies, or dramas, or both. Possible genres here are: 'Action', 'Thriller, 'Drama', 'Western', 'Historical', 'Romance', 'Animation', 'Horror', 'Science Fiction', and 'Comedy'.</remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("api/movies")]
        public async Task<ActionResult<IEnumerable<MovieItem>>> SearchMovies(MovieSearchItem item) {
            List<MovieItem> r_list = new List<MovieItem>();
            //=== Build the movie query
            bool is_valid_query = false;
            var query = _context.Movies.Select(q => q);
            if (item.title.Trim().Length == 1 || _badMovieTitleList.Contains(item.title.Trim().ToLower())) {
                return BadRequest("The movie title: " + item.title + " is invalid. Single character searches, or simple words (a, an, and, the, or) are not allowed.");
            }
            if (!string.IsNullOrEmpty(item.title.Trim())) {
                is_valid_query = true;
                query = query.Where(q => q.title.ToLower().Contains(item.title.ToLower()));
            }
            if (item.yearOfRelease != 0) {
                if (item.yearOfRelease < 1900 || item.yearOfRelease > 2050) {
                    return BadRequest("The yearOfRelease must be specified as a four digit date greater than 1900 and less than 2050.");
                } else if (item.yearOfRelease > 0) {
                    is_valid_query = true;
                    query = query.Where(q => q.yearOfRelease == item.yearOfRelease);
                }
            }
            if (!String.IsNullOrEmpty(item.genres.Trim())) {
                is_valid_query = true;
                List<string> genre_s_list = item.genres.ToLower().Split(',').ToList();
                List<long> genre_movie_id_list = _context.Genres.Join(
                    _context.MovieGenres,
                    a => a.id,
                    b => b.genreId,
                    (a, b) => new { a, b }
                    ).Where(q => genre_s_list.Contains(q.a.genreName.ToLower())).Select(q => q.b.movieId).ToList();
                query = query.Where(q => genre_movie_id_list.Contains(q.id));
            }
            if (!is_valid_query) {
                return BadRequest("Current search terms are invalid. You must search by at least one valid title, yearOfRelease, or genre.");
            }
            await query.ForEachAsync(q => r_list.Add(new MovieItem { id = q.id, title = q.title, runningTime = q.runningTime, yearOfRelease = q.yearOfRelease }));
            //=== Add genres and ratings, return the query
            if (r_list.Count == 0) {
                return NotFound("No movie with this search criteria was found.");
            } else {
                List<long> movie_id_list = r_list.Select(q => q.id).ToList();
                var movie_genre_list = _context.MovieGenres.Join(
                    _context.Genres,
                    a => a.genreId,
                    b => b.id,
                    (a, b) => new { a, b }
                    ).Where(q => movie_id_list.Contains(q.a.movieId)).ToList();
                var rating_list = _context.Ratings.GroupBy(
                    t => new { movieId = t.movieId })
                    .Select(q => new { Average = q.Average(p => p.rating), q.Key.movieId })
                    .Where(q => movie_id_list.Contains(q.movieId)).ToList();
                foreach (MovieItem the_item in r_list) {
                    the_item.genres = String.Join(',', movie_genre_list.Where(q => q.a.movieId == the_item.id).Select(q => q.b.genreName).ToList());
                    the_item.averageRating = Math.Round(rating_list.Where(q => q.movieId == the_item.id).Select(q => q.Average).SingleOrDefault() * 2, MidpointRounding.ToEven) / 2;
                }
                r_list = r_list.OrderByDescending(q => q.averageRating).ThenBy(q => q.title).ToList();
                return r_list;
            }

        }
        /// <summary>
        /// Updates the moving rating for a single user, and a single movie. If the user has not yet added a rating for this movie, a new row is added
        /// </summary>
        /// <remarks>
        /// <b>userId</b> is the integer userId for this fictitious user. The in-memory database will automatically add ratings for users from 1-4 here. There is no associated user table to define users (out-of-scope). If a userId does not exist, a new row will be added here. I understand this is not perfect in terms of sniffing out users that do not yet exist, but I ran out of time to add a user table.
        /// <b>movieId</b> is the integer movieId for the movies in the system. There are 20 movies seeded in to start (movieId 1-20). 
        /// <b>rating</b> is the rating (1-5) you wish to assign to this movie. Integers that are outside of this range will throw a 400 status code, and not affect the database.
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("api/movieRatings")]
        public async Task<ActionResult> UpdateMovieRating(MovieUserRating the_rating) {
            if (the_rating.rating < 1 || the_rating.rating > 5) {
                return BadRequest("Invalid rating for this movie. Ratings must be between 1 - 5.");
            }
            if (_context.Movies.Where(q => q.id == the_rating.movieId).Count() == 0) {
                return BadRequest("Invalid movieId for movie with an id of: " + the_rating.movieId);
            }
            Rating db_rating = await _context.Ratings.Where(q => q.userId == the_rating.userId && q.movieId == the_rating.movieId).SingleOrDefaultAsync();
            if (db_rating == null) {
                db_rating = new Rating { userId = the_rating.userId, movieId = the_rating.movieId };
                //the below is a bit of a HACK to increment the id of the inserted Rating row. 
                //Generally, I would rely on the DatabaseGeneratedOption.Identity decoration in the Rating class to handle this for me (and the decoration is there)
                //but in the case of in memory stuff, this doesn't work properly. So, I chose to just increment the id manually. There would be race conditions at 
                //scale (of course), but since this is local, it should work fine.
                db_rating.id = _context.Ratings.Max(q => q.id) + 1;
                _context.Ratings.Add(db_rating);
            }
            db_rating.rating = the_rating.rating;
            await _context.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// Returns top five movies (in descending order) in terms of average rating, for the user_id you pass in.
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/topFiveMovies/{user_id}")]
        public async Task<ActionResult<List<MovieItem>>> GetTopFiveFromUser(int user_id) {
            var query = await _context.Ratings.Where(q => q.userId == user_id).GroupBy(t => new { movieId = t.movieId }).Select(q => new { Average = q.Average(p => p.rating), q.Key.movieId }).OrderByDescending(q => q.Average).Take(5).ToListAsync();
            Dictionary<long, double> movie_id_dict = query.Select(q => new { q.movieId, q.Average }).ToDictionary(q => q.movieId, q => q.Average);
            return await MakeTopFiveMovieItems(movie_id_dict);
        }
        /// <summary>
        /// Returns top five movies (in descending order) in terms of average rating, for the movie system as a whole.
        /// </summary>        
        [HttpGet]
        [Route("api/topFiveMovies")]
        public async Task<ActionResult<List<MovieItem>>> GetTopFive() {
            var query = await _context.Ratings.GroupBy(t => new { movieId = t.movieId }).Select(q => new { Average = q.Average(p => p.rating), q.Key.movieId }).OrderByDescending(q => q.Average).Take(5).ToListAsync();
            Dictionary<long, double> movie_id_dict = query.Select(q => new { q.movieId, q.Average }).ToDictionary(q => q.movieId, q => q.Average);
            return await MakeTopFiveMovieItems(movie_id_dict);
        }
        private async Task<ActionResult<List<MovieItem>>> MakeTopFiveMovieItems(Dictionary<long, double> movie_id_dict) {
            List<MovieItem> r_list = new List<MovieItem>();
            List<Movie> movie_list = await _context.Movies.Where(q => movie_id_dict.Keys.Contains(q.id)).ToListAsync();
            var movie_genre_list = _context.MovieGenres.Join(
                _context.Genres,
                a => a.genreId,
                b => b.id,
                (a, b) => new { a, b }
                ).Where(q => movie_id_dict.Keys.Contains(q.a.movieId)).ToList();
            foreach (Movie the_movie in movie_list) {
                MovieItem new_item = new MovieItem {
                    id = the_movie.id,
                    title = the_movie.title,
                    runningTime = the_movie.runningTime,
                    yearOfRelease = the_movie.yearOfRelease,
                    averageRating = Math.Round(movie_id_dict[the_movie.id] * 2, MidpointRounding.ToEven) / 2 };
                new_item.genres = String.Join(',', movie_genre_list.Where(q => q.a.movieId == new_item.id).Select(q => q.b.genreName).ToList());
                r_list.Add(new_item);
            }
            return r_list.OrderByDescending(q => q.averageRating).ThenBy(q => q.title).ToList();
        }

    }
}