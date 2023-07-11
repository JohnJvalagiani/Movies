using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Models
{
    public class WatchlistItemRequest
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public bool IsWatched { get; set; }
    }
}
