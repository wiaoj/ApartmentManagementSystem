using Application.Handlers.Vehicles.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.Vehicles.Commands.Update;
public class UpdateVehicleValidator : AbstractValidator<UpdateVehicleCommand> {
    public UpdateVehicleValidator() {
        RuleFor(x => x.Id).Id();
        RuleFor(x => x.UserId).Id();
        RuleFor(x => x.Plate).Plate();
    }
}