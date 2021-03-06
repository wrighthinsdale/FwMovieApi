﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FwMovieApi.DbModels {
    public class Movie {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string title { get; set; }
        public int yearOfRelease { get; set; }
        public int runningTime { get; set; }
    }
}
