using Application.Handlers.Apartments.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.Apartments.Commands.Create;
public class CreateApartmentValidator : AbstractValidator<CreateApartmentCommand> {
    public CreateApartmentValidator() {
        RuleFor(x => x.Number).Number();
        RuleFor(x => x.BlockNo).BlockNo();
        RuleFor(x => x.Floor).Floor();
        RuleFor(x => x.Type).Type();
        RuleFor(x => x.ApartmentState).ApartmentState();
    }
}