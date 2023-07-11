using Movies.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Services.Interfaces
{
    public interface ITmdbApiService
    {
        public Task<IEnumerable<MovieResponse>> SearchMovies(string title, int year);
    }
}
