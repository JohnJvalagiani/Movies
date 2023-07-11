using MediatR;
using Movies.Application.Models;

namespace Movies.API.Commands
{
    public class MovieSearchQuery : IRequest<List<MovieResponse>>
    {
        public string Title { get; set; }
        public int Year { get; set; }
        // Add other search parameters as needed
    }

}
