using Application.Handlers.PhoneNumbers.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.PhoneNumbers.Commands.Delete;
public class DeletePhoneNumberValidator : AbstractValidator<DeletePhoneNumberCommand> {
	public DeletePhoneNumberValidator() {
		RuleFor(x => x.Id).Id();
	}
}