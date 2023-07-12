﻿using MediatR;
using Movies.API.Commands;
using Movies.Application.Services.Interfaces;

namespace Movies.API.Handlers
{
    public class MarkAsWatchedCommandHandler : IRequestHandler<MarkAsWatchedCommand>
    {
        private readonly IMovieWatchlistService _watchlistService;

        public MarkAsWatchedCommandHandler(IMovieWatchlistService watchlistService)
        {
            _watchlistService = watchlistService;
        }

        public async Task<Unit> Handle(MarkAsWatchedCommand request, CancellationToken cancellationToken)
        {
            // Call the watchlist service to mark the movie as watched for the user
            await _watchlistService.MarkAsWatched(request.UserId, request.MovieId);
            return Unit.Value;
        }
    }
}
