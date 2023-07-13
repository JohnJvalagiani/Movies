using FluentValidation;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Movies.API.Commands;

namespace Movies.API.Valodators
{
    public class CreateMovieSearchCommandValidator:AbstractValidator<MovieSearchCommand> 
    {
        public CreateMovieSearchCommandValidator()
        {
            RuleFor(x => x.searchQuery)
                .NotEmpty();
        }
    }
}
