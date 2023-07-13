using MediatR;
using Movies.Application.Models;

namespace Movies.API.Commands
{
    public class MarkAsWatchedCommand : IRequest<WatchlistItemResponse>
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
