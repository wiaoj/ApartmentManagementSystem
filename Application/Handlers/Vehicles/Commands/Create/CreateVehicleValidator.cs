using Application.Handlers.Vehicles.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.Vehicles.Commands.Create;
public class CreateVehicleValidator : AbstractValidator<CreateVehicleCommand> {
    public CreateVehicleValidator() {
        RuleFor(x => x.UserId).Id();
        RuleFor(x => x.Plate).Plate();
    }
}