using MediatR;
using Movies.Application.Models;

namespace Movies.API.Commands
{
    public class MovieSearchCommand : IRequest<List<MovieResponse>>
    {
        public string searchQuery { get; set; }
    }

}
