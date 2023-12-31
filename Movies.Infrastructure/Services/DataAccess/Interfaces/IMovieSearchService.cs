﻿using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Services.Interfaces
{
    public interface IMovieSearchService
    {
        Task<MovieList> SearchMovies(string searchQuery);
    }

}
