using MediatR;
using Movies.Application.Models;

namespace Movies.API.Commands
{
    public class MovieSearchQuery : IRequest<List<MovieResponse>>
    {
        public string searchQuery { get; set; }
    }

}
