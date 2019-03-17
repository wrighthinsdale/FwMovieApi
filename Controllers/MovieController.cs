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
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase {
        private readonly MovieContext _context;
        private static List<string> _badMovieTitleList = (new string[] { "a", "an", "and", "the", "or" }).ToList();
        public MovieController(MovieContext context) {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<MovieItem>>> GetMovies() {
            List<MovieItem> r_list = new List<MovieItem>();
            await _context.Movies.ForEachAsync(q => r_list.Add(new MovieItem { id = q.id, title = q.title, runningTime = q.runningTime, yearOfRelease = q.yearOfRelease}));
            return r_list;
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<MovieItem>>> SearchMovies(MovieSearchItem item) {
            List<MovieItem> r_list = new List<MovieItem>();
            var query = _context.Movies.Select(q => q);
            if (item.title.Trim().Length == 1 || _badMovieTitleList.Contains(item.title.Trim().ToLower())) {
                return BadRequest("The movie title: " + item.title + " is invalid. Single character searches, or simple words (a, an, and, the, or) are not allowed.");
            }
            if (!string.IsNullOrEmpty(item.title.Trim())) {
                query = query.Where(q => q.title.ToLower().Contains(item.title.ToLower()));
            }
            if (item.yearOfRelease < 0 || item.yearOfRelease < 1900 || item.yearOfRelease > 2050) {
                return BadRequest("The yearOfRelease must be specified as a four digit date greater than 1900 and less than 2050.");
            }else if (item.yearOfRelease > 0) {
                query = query.Where(q => q.yearOfRelease == item.yearOfRelease);
            }
            await query.ForEachAsync(q => r_list.Add(new MovieItem { id = q.id, title = q.title, runningTime = q.runningTime, yearOfRelease = q.yearOfRelease }));
            if (r_list.Count == 0) {
                return NotFound("No movie with this search criteria was found.");
            } else {
                return r_list;
            }
            
        }
    }
}