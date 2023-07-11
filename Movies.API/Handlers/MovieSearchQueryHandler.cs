using MediatR;
using Movies.API.Commands;
using Movies.Application.Models;
using Movies.Application.Services.Interfaces;

namespace Movies.API.Handlers
{
    public class MovieSearchQueryHandler : IRequestHandler<MovieSearchQuery, List<MovieResponse>>
    {
        private readonly ITmdbApiService _imdbApiService;

        public MovieSearchQueryHandler(ITmdbApiService imdbApiService)
        {
            _imdbApiService = imdbApiService;
        }

        public async Task<List<MovieResponse>> Handle(MovieSearchQuery request, CancellationToken cancellationToken)
        {
            // Call the IMDb API service to search for movies
            var movies = await _imdbApiService.SearchMovies(request.Title, request.Year);
            return movies.ToList();
        }
    }
}
