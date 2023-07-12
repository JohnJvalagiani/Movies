using AutoMapper;
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

        public async Task<Unit> Handle(AddToWatchlistCommand request, CancellationToken cancellationToken)
        {
            var response=await _movieWatchlistService.AddToWatchlist();
            return new Unit();
        }
    }
}
