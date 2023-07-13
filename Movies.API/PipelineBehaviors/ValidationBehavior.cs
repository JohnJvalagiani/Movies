﻿using FluentValidation;
using MediatR;
using System.Buffers;
using System.ComponentModel.DataAnnotations;

namespace Movies.API.PipelineBehaviors
{
   


    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationContext = new FluentValidation.ValidationContext<TRequest>(request);
            var validationResults = new List<ValidationResult>();

            foreach (var validator in _validators)
            {
                var result = await validator.ValidateAsync(validationContext, cancellationToken).ConfigureAwait(false);
                if (!result.IsValid)
                {
                    var failures = result.Errors.Select(error => error.ErrorMessage).ToList();
                    var failureMessage = string.Join(", ", failures);
                    throw new FluentValidation.ValidationException(failureMessage);
                }
            }
            return await next().ConfigureAwait(false);
        }

    }


}
