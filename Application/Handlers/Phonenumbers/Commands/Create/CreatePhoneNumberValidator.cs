using Application.Handlers.Phonenumbers.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.Phonenumbers.Commands.Create;
public class CreatePhoneNumberValidator : AbstractValidator<CreatePhoneNumberCommand> {
	public CreatePhoneNumberValidator() {
		RuleFor(x => x.CountryCode).CountryCode();
		RuleFor(x => x.Number).Number();
		RuleFor(x => x.UserId).Id();
	}
}