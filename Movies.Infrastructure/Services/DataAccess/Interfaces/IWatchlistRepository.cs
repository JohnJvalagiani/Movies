﻿using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Services.DataAccess.Interfaces
{
    public interface IWatchlistRepository
    {
        Task AddToWatchlist(int userId, Movie movie);
        Task MarkAsWatched(int userId, int movieId);
        Task<List<WatchlistItem>> GetWatchlistItems(int userId);
    }
}
