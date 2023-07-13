using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Commands;
using Movies.API.Query;
using Movies.Application.Models;
using Movies.Domain.Entities;

namespace Movies.API.Controllers
{

    public class MoviesController : BaseController
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("SearchMovies")]
        public async Task<ActionResult<List<MovieResponse>>> SearchMovies([FromQuery] MovieSearchCommand query)
        {
            var movies = await _mediator.Send(query);
            return movies;
        }

        [HttpPost("AddToWatchlist")]
        public async Task<IActionResult> AddToWatchlist(AddMovieToWatchlistCommand command)
        {
            var watchListItem=await _mediator.Send(command);
            return CreatedAtAction(nameof(AddToWatchlist), watchListItem);
        }

        [HttpPut("MarkAsWatched/{movieId}/watched")]
        public async Task<IActionResult> MarkAsWatched( [FromBody] MarkAsWatchedCommand command)
        {
            var watchlistItem=await _mediator.Send(command);
            return watchlistItem != null ? Ok(watchlistItem) : NotFound();
        }

        [HttpGet("GetWatchlistItems/{userId}")]
        public async Task<ActionResult<List<WatchlistItemResponse>>> GetWatchlistItems(int userId)
        {
            var query = new GetWatchlistItemsQuery { UserId = userId };
            var watchlistItems = await _mediator.Send(query);
            return watchlistItems != null ? Ok(watchlistItems) : NotFound();
        }
    }

}
