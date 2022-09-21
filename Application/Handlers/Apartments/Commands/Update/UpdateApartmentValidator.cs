using Application.Handlers.Apartments.Common.ValidationExtension;
using Domain.Enums;
using FluentValidation;

namespace Application.Handlers.Apartments.Commands.Update;
public class UpdateApartmentValidator : AbstractValidator<UpdateApartmentCommand> {
    public UpdateApartmentValidator() {
        RuleFor(x => x.Id).Id();
        RuleFor(x => x.Number).Number();
        RuleFor(x => x.BlockNo).BlockNo();
        RuleFor(x => x.Floor).Floor();
        RuleFor(x => x.Type).Type();
        RuleFor(x => x.ApartmentState).ApartmentState();
    }
}