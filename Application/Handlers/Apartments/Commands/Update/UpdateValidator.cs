using FluentValidation;

namespace Application.Handlers.Apartments.Commands.Update;
public class UpdateValidator : AbstractValidator<UpdateCommand> {
    public UpdateValidator() {

    }
}