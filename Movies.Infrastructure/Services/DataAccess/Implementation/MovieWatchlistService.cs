using Movies.Application.Models;
using Movies.Application.Services.Interfaces;
using Movies.Infrastructure.Services.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Services.Implementation
{
    public class MovieWatchlistService : IMovieWatchlistService
    {
        private readonly IWatchlistRepository _watchlistRepository;

        public MovieWatchlistService(IWatchlistRepository watchlistRepository)
        {
            _watchlistRepository = watchlistRepository;
        }

        public async Task AddToWatchlist(int userId, Movie movie)
        {
            await _watchlistRepository.AddToWatchlist(userId, movie);
        }

        public async Task MarkAsWatched(int userId, int movieId)
        {
            await _watchlistRepository.MarkAsWatched(userId, movieId);
        }

        public async Task<List<WatchlistItemResponse>> GetWatchlistItems(int userId)
        {
            // Retrieve the watchlist items for the user from the repository
            var watchlistItems = await _watchlistRepository.GetWatchlistItems(userId);
            return watchlistItems;
        }
    }

}
