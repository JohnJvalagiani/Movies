using FluentValidation;
using Movies.API.Commands;

namespace Movies.API.Valodators
{
    public class AddMovieToWatchlistCommandValidator : AbstractValidator<AddMovieToWatchlistCommand>
    {
        public AddMovieToWatchlistCommandValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.MovieId)
              .NotEmpty()
              .NotNull();
        }
    }
}
