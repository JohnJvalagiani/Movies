using MediatR;
using Movies.Application.Models;

namespace Movies.API.Query
{
    public class GetWatchlistItemsQuery : IRequest<List<WatchlistItemResponse>>
    {
        public int UserId { get; set; }
    }
}
