using MediatR;
using Movies.Application.Models;

namespace Movies.API.Commands
{
    public class AddMovieToWatchlistCommand : IRequest<WatchlistItemResponse>
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string MovieTitel { get; set; }
    }
}
