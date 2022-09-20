using Application.Handlers.Phonenumbers.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.Phonenumbers.Commands.Delete;
public class DeletePhoneNumberValidator : AbstractValidator<DeletePhoneNumberCommand> {
	public DeletePhoneNumberValidator() {
		RuleFor(x => x.Id).Id();
	}
}