using MediatR;
using Movies.API.Commands;
using Movies.Application.Models;
using Movies.Application.Services.Interfaces;

namespace Movies.API.Handlers
{
    public class AddToWatchlistCommandHandler : IRequestHandler<AddToWatchlistCommand>
    {
        private readonly IMovieWatchlistService _movieWatchlistService;

        public AddToWatchlistCommandHandler(IMovieWatchlistService movieWatchlistService)
        {
            _movieWatchlistService = movieWatchlistService;
        }

        public async Task<WatchlistItemResponse> Handle(AddToWatchlistCommand request, CancellationToken cancellationToken)
        {
            // Call the watchlist service to add the movie to the user's watchlist
            var response=await _movieWatchlistService.AddToWatchlist();
            return response;
        }
    }
}
