﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class MovieList
    {
        public List<Movie> results { get; set; }    
        public int total_results { get; set; }
    }
}
