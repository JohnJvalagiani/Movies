using Movies.Application.Services.Interfaces;
using Movies.Domain.Entities;
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

        public async Task<WatchlistItem> AddToWatchlist(WatchlistItem watchlistItem)
        {
           return await _watchlistRepository.AddToWatchlist(watchlistItem);
        }

        public async Task<List<WatchlistItem>> GetWatchlistItems(int userId)
        {
            var watchlistItems = await _watchlistRepository.GetWatchlistItems(userId);
            return watchlistItems;
        }

        public async Task<WatchlistItem> MarkAsWatched(int userId, int movieId)
        {
            return await _watchlistRepository.MarkAsWatched(userId, movieId);
        }
    }

}
