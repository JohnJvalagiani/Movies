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

        public async Task<bool> AddToWatchlist(WatchlistItem watchlistItem)
        {
            await _watchlistRepository.AddToWatchlist(watchlistItem);
            return true;
        }

        public async Task<List<WatchlistItem>> GetWatchlistItems(int userId)
        {
            var watchlistItems = await _watchlistRepository.GetWatchlistItems(userId);
            return watchlistItems;
        }

        public async Task<bool> MarkAsWatched(int userId, int movieId)
        {
            await _watchlistRepository.MarkAsWatched(userId, movieId);
            return true;
        }
    }

}
