using FluentValidation;
using Movies.API.Commands;

namespace Movies.API.Valodators
{
    public class MarkAsWatchedCommandValidator : AbstractValidator<MarkAsWatchedCommand>
    {
        public MarkAsWatchedCommandValidator()
        {
            RuleFor(x => x.UserId)
               .NotEmpty()
               .NotNull();
        }
    }
}
