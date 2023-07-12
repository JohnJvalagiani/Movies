using AutoMapper;
using MediatR;
using Movies.API.Query;
using Movies.Application.Models;
using Movies.Application.Services.Interfaces;

namespace Movies.API.Handlers
{
    public class GetWatchlistItemsQueryHandler : IRequestHandler<GetWatchlistItemsQuery, List<WatchlistItemResponse>>
    {
        private readonly IMovieWatchlistService _watchlistService;
        private readonly IMapper _mapper;

        public GetWatchlistItemsQueryHandler(IMovieWatchlistService watchlistService, IMapper mapper)
        {
            _watchlistService = watchlistService;
            _mapper = mapper;
        }

        public async Task<List<WatchlistItemResponse>> Handle(GetWatchlistItemsQuery request, CancellationToken cancellationToken)
        {
            // Call the watchlist service to retrieve the watchlist items for the user
            var watchlistItems = await _watchlistService.GetWatchlistItems(request.UserId);
            return _mapper.Map<List< WatchlistItemResponse >>( watchlistItems);
        }
    }
}
