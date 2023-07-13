using AutoMapper;
using MediatR;
using Movies.API.Commands;
using Movies.Application.Models;
using Movies.Application.Services.Interfaces;

namespace Movies.API.Handlers
{
    public class MovieSearchQueryHandler : IRequestHandler<MovieSearchCommand, List<MovieResponse>>
    {
        private readonly ITmdbApiService _imdbApiService;
        private readonly IMapper _mapper;

        public MovieSearchQueryHandler(ITmdbApiService imdbApiService, IMapper mapper)
        {
            _imdbApiService = imdbApiService;
            _mapper = mapper;
        }

        public async Task<List<MovieResponse>> Handle(MovieSearchCommand request, CancellationToken cancellationToken)
        {
            var movies = await _imdbApiService.SearchMovies(request.searchQuery);
            return _mapper.Map<List<MovieResponse>>( movies.results);
        }
    }
}
