using Application.Handlers.Apartments.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.Apartments.Commands.Delete;
public class DeleteApartmentValidator : AbstractValidator<DeleteApartmentCommand> {
    public DeleteApartmentValidator() {
        RuleFor(x => x.Id).Id();
    }
}