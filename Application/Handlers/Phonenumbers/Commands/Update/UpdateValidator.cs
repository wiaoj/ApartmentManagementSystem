using Application.Handlers.Apartments.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.Phonenumbers.Commands.Update;
public class UpdatePhoneNumberValidator : AbstractValidator<UpdatePhoneNumberCommand> {
	public UpdatePhoneNumberValidator() {
		RuleFor(x => x.Id).Id();
	}
}