using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Commands;
using Movies.API.Query;
using Movies.Application.Models;

namespace Movies.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Endpoint for searching movies
        [HttpGet("search")]
        public async Task<ActionResult<List<MovieResponse>>> SearchMovies([FromQuery] MovieSearchQuery query)
        {
            var movies = await _mediator.Send(query);
            return movies;
        }

        // Endpoint for adding a movie to the watchlist
        [HttpPost("watchlist")]
        public async Task<IActionResult> AddToWatchlist(AddToWatchlistCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        // Endpoint for marking a movie as watched
        [HttpPut("watchlist/{movieId}/watched")]
        public async Task<IActionResult> MarkAsWatched(int movieId, [FromBody] MarkAsWatchedCommand command)
        {
            command.MovieId = movieId;
            await _mediator.Send(command);
            return Ok();
        }

        //// Endpoint for getting the watchlist items for a user
        //[HttpGet("watchlist/{userId}")]
        //public async Task<ActionResult<List<WatchlistItemResponse>>> GetWatchlistItems(int userId)
        //{
        //    var query = new GetWatchlistItemsQuery { UserId = userId };
        //    var watchlistItems = await _mediator.Send(query);
        //    return watchlistItems;
        //}
    }

}
