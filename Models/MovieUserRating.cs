using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FwMovieApi.Models {
    public class MovieUserRating {
        public int userId { get; set; }
        public long movieId { get; set; }
        public int rating { get; set; }
    }
}
