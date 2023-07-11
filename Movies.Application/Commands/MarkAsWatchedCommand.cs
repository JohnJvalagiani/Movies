using MediatR;

namespace Movies.API.Commands
{
    public class MarkAsWatchedCommand : IRequest
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}
