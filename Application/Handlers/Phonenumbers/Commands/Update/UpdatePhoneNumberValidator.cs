using Application.Handlers.PhoneNumbers.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.PhoneNumbers.Commands.Update;
public class UpdatePhoneNumberValidator : AbstractValidator<UpdatePhoneNumberCommand> {
    public UpdatePhoneNumberValidator() {
        RuleFor(x => x.Id).Id();
    }
}