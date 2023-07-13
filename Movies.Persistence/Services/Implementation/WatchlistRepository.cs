using Microsoft.EntityFrameworkCore;
using Movies.Domain.Entities;
using Movies.Infrastructure.Services.DataAccess.Interfaces;
using Movies.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Services.DataAccess.Implementation
{
    public class WatchlistRepository : IWatchlistRepository
    {
        private readonly MovieDbContext _dbContext;

        public WatchlistRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WatchlistItem> AddToWatchlist(WatchlistItem watchlistItem)
        {
            Guid guid = Guid.NewGuid();
            var theWatchlistItem = new WatchlistItem
            {
                Id = guid.GetHashCode(),
                UserId = watchlistItem.UserId,
                MovieId = watchlistItem.MovieId,
                Title = watchlistItem.Title,
                IsWatched= watchlistItem.IsWatched,
            };

            _dbContext.WatchlistItems.Add(watchlistItem);
            try
            {
            var result = await _dbContext.SaveChangesAsync();
                return theWatchlistItem;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<WatchlistItem> MarkAsWatched(int userId, int movieId)
        {
            var watchlistItem = await _dbContext.WatchlistItems
                .FirstOrDefaultAsync(w => w.UserId == userId && w.MovieId == movieId);

            if (watchlistItem == null)
                throw new DirectoryNotFoundException("$\"Content with movie Id {movieId} and with user Id {userId} not found.\"");

            watchlistItem.IsWatched = true;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return watchlistItem;
        }

        public async Task<List<WatchlistItem>> GetWatchlistItems(int userId)
        {
            var watchlistItems = await _dbContext.WatchlistItems
                .Where(w => w.UserId == userId)
                .ToListAsync();

            if (watchlistItems == null)
                throw new DirectoryNotFoundException("$\"Content with user Id {userId} not found.\"");

            return watchlistItems;
        }
    }
}
