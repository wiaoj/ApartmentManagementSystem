﻿using FluentValidation.Results;
using FluentValidation;
using MediatR;

namespace Application.Pipelines;
public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse> {
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators) {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
                                  RequestHandlerDelegate<TResponse> next) {
        ValidationContext<Object> context = new(request);
        List<ValidationFailure> failures = _validators
                                           .Select(validator => validator.Validate(context))
                                           .SelectMany(result => result.Errors)
                                           .Where(failure => failure is not null)
                                           .ToList();
        if(failures.Count is not 0)
            throw new ValidationException(failures);
        return next();
    }
}