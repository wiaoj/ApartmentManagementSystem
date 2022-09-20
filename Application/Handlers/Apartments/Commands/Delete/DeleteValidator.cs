using FluentValidation;

namespace Application.Handlers.Apartments.Commands.Delete;
public class DeleteValidator : AbstractValidator<DeleteCommand> {
	public DeleteValidator() {

	}
}