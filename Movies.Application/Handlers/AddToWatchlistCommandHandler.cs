using AutoMapper;
using MediatR;
using Movies.API.Commands;
using Movies.Application.Models;
using Movies.Application.Services.Interfaces;
using Movies.Domain.Entities;

namespace Movies.API.Handlers
{
    public class AddToWatchlistCommandHandler : IRequestHandler<AddMovieToWatchlistCommand, WatchlistItemResponse>
    {
        private readonly IMovieWatchlistService _movieWatchlistService;
        private readonly IMapper _mapper;

        public AddToWatchlistCommandHandler(IMovieWatchlistService movieWatchlistService, IMapper mapper)
        {
            _mapper = mapper;
            _movieWatchlistService = movieWatchlistService;
        }

        public async Task<WatchlistItemResponse> Handle(AddMovieToWatchlistCommand request, CancellationToken cancellationToken)
        {
            var response=await _movieWatchlistService.AddToWatchlist(_mapper.Map<WatchlistItem>(request));
            return _mapper.Map<WatchlistItemResponse>(response);
        }
    }
}
