//using MediatR;
//using Movies.API.Commands;

//namespace Movies.API.Handlers
//{
//    public class AddToWatchlistCommandHandler : IRequestHandler<AddToWatchlistCommand>
//    {
//        private readonly IWatchlistService _watchlistService;

//        public AddToWatchlistCommandHandler(IWatchlistService watchlistService)
//        {
//            _watchlistService = watchlistService;
//        }

//        public async Task<Unit> Handle(AddToWatchlistCommand request, CancellationToken cancellationToken)
//        {
//            // Call the watchlist service to add the movie to the user's watchlist
//            await _watchlistService.AddToWatchlist(request.UserId, request.MovieId);
//            return Unit.Value;
//        }
//    }
//}
