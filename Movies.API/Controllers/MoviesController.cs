using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Commands;
using Movies.API.Query;
using Movies.Application.Models;

namespace Movies.API.Controllers
{

    public class MoviesController : BaseController
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<MovieResponse>>> SearchMovies([FromQuery] MovieSearchCommand query)
        {
            var movies = await _mediator.Send(query);
            return movies;
        }

        [HttpPost("watchlist")]
        public async Task<IActionResult> AddToWatchlist(AddMovieToWatchlistCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("watchlist/{movieId}/watched")]
        public async Task<IActionResult> MarkAsWatched(int movieId, [FromBody] MarkAsWatchedCommand command)
        {
            command.MovieId = movieId;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("watchlist/{userId}")]
        public async Task<ActionResult<List<WatchlistItemResponse>>> GetWatchlistItems(int userId)
        {
            var query = new GetWatchlistItemsQuery { UserId = userId };
            var watchlistItems = await _mediator.Send(query);
            return watchlistItems;
        }
    }

}
