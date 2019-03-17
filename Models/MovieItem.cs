using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FwMovieApi.Models {
    public class MovieItem {
        public long id { get; set; }
        public string title { get; set; }
        public int yearOfRelease { get; set; }
        public int runningTime { get; set; }
        public string genres { get; set; }
        public float averageRating { get; set; }
    }
}
