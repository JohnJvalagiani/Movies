using MediatR;

namespace Movies.API.Commands
{
    public class AddToWatchlistCommand : IRequest
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
