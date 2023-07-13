using FluentValidation;
using Movies.API.Commands;
using Movies.API.Query;

namespace Movies.API.Valodators
{
    public class GetWatchlistItemsQueryValidator : AbstractValidator<GetWatchlistItemsQuery>
    {
        public GetWatchlistItemsQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();
        }
    }
}
