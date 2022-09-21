using Application.Handlers.Vehicles.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.Vehicles.Commands.Delete;
public class DeleteVehicleValidator : AbstractValidator<DeleteVehicleCommand> {
    public DeleteVehicleValidator() {
        RuleFor(x => x.Id).Id();
    }
}