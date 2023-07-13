using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Services.DataAccess.Interfaces
{
    public interface IWatchlistRepository
    {
        Task<WatchlistItem> AddToWatchlist(WatchlistItem watchlistItem);
        Task<WatchlistItem> MarkAsWatched(int userId, int movieId);
        Task<List<WatchlistItem>> GetWatchlistItems(int userId);
    }
}
