using MediatR;
using Movies.Application.Models;

namespace Movies.API.Query
{
    public class GetWatchlistItemsQuery : IRequest<List<WatchlistItemRequest>>
    {
        public int UserId { get; set; }
    }
}
