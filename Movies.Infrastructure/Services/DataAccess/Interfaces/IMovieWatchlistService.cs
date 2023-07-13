﻿using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Services.Interfaces
{
    public interface IMovieWatchlistService
    {
        public Task<bool> AddToWatchlist(WatchlistItem watchlistItem);
        public Task<bool> MarkAsWatched(int userId, int movieId);
        public Task<List<WatchlistItem>> GetWatchlistItems(int userId);
    }

}
