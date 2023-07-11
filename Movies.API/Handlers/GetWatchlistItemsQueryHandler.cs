//using MediatR;
//using Movies.API.Query;
//using Movies.Application.Models;

//namespace Movies.API.Handlers
//{
//    public class GetWatchlistItemsQueryHandler : IRequestHandler<GetWatchlistItemsQuery, List<WatchlistItemRequest>>
//    {
//        private readonly IWatchlistService _watchlistService;

//        public GetWatchlistItemsQueryHandler(IWatchlistService watchlistService)
//        {
//            _watchlistService = watchlistService;
//        }

//        public async Task<List<WatchlistItemRequest>> Handle(GetWatchlistItemsQuery request, CancellationToken cancellationToken)
//        {
//            // Call the watchlist service to retrieve the watchlist items for the user
//            var watchlistItems = await _watchlistService.GetWatchlistItems(request.UserId);
//            return watchlistItems;
//        }
//    }
//}
