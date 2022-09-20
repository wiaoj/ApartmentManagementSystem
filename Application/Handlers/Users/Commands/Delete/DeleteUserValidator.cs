using Application.Handlers.Users.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.Users.Commands.Delete;
public class DeleteUserValidator : AbstractValidator<DeleteUserCommand> {
	public DeleteUserValidator() {
		RuleFor(x => x.Id).Id();
	}
}