using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FwMovieApi.Models {
    public class MovieSearchItem {
        public string title { get; set; }
        public int yearOfRelease { get; set; }
        public string genres { get; set; }
    }
}
