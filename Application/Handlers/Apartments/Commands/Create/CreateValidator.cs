using FluentValidation;

namespace Application.Handlers.Apartments.Commands.Create;
public class CreateValidator : AbstractValidator<CreateCommand> {
    public CreateValidator() {

    }
}