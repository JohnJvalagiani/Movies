using AutoMapper;
using MediatR;
using Movies.API.Commands;
using Movies.Application.Models;
using Movies.Application.Services.Interfaces;

namespace Movies.API.Handlers
{
    public class MarkAsWatchedCommandHandler : IRequestHandler<MarkAsWatchedCommand, WatchlistItemResponse>
    {
        private readonly IMovieWatchlistService _watchlistService;
        private readonly IMapper _mapper;
        public MarkAsWatchedCommandHandler(IMovieWatchlistService watchlistService, IMapper mapper)
        {
            _mapper = mapper;
            _watchlistService = watchlistService;
        }

        public async Task<WatchlistItemResponse> Handle(MarkAsWatchedCommand request, CancellationToken cancellationToken)
        {
            var markedmovie=await _watchlistService.MarkAsWatched(request.UserId, request.MovieId);
            return _mapper.Map<WatchlistItemResponse>(markedmovie);
        }
    }
}
