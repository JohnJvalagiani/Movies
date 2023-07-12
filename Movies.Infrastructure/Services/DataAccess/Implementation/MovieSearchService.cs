using Movies.Application.Services.Interfaces;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Services.Implementation
{
    public class MovieSearchService : IMovieSearchService
    {
        private readonly ITmdbApiService _imdbApiService;

        public MovieSearchService(ITmdbApiService imdbApiService)
        {
            _imdbApiService = imdbApiService;
        }

        public async Task<IEnumerable<Movie>> SearchMovies(string title, int year)
        {
            var movies = await _imdbApiService.SearchMovies(title, year);
            return movies;
        }
    }

}
