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

        public async Task AddToWatchlist(WatchlistItem watchlistItem)
        {
            var theWatchlistItem = new WatchlistItem
            {
                UserId = watchlistItem.UserId,
                MovieId = watchlistItem.MovieId,
                Title = watchlistItem.Title,
                IsWatched= watchlistItem.IsWatched,
            };
            _dbContext.WatchlistItems.Add(watchlistItem);
            var result= await _dbContext.SaveChangesAsync();
            if(result==0)
            {
               
            }
        }

        public async Task MarkAsWatched(int userId, int movieId)
        {
            var watchlistItem = await _dbContext.WatchlistItems
                .FirstOrDefaultAsync(w => w.UserId == userId && w.MovieId == movieId);

            if (watchlistItem != null)
            {
                watchlistItem.IsWatched = true;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<WatchlistItem>> GetWatchlistItems(int userId)
        {
            var watchlistItems = await _dbContext.WatchlistItems
                .Where(w => w.UserId == userId)
                .ToListAsync();

            return watchlistItems;
        }
    }
}
