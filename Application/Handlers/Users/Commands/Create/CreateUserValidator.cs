using Application.Handlers.Users.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.Users.Commands.Create;
public class CreateUserValidator : AbstractValidator<CreateUserCommand> {
    public CreateUserValidator() {
        RuleFor(x => x.FirstName).FirstName();
        RuleFor(x => x.LastName).LastName();
        RuleFor(x => x.IdentityNumber).IdentityNumber();
        RuleFor(x => x.Email).Email();
        RuleFor(x => x.IsTenant).Tenant();
        RuleFor(x => x.ApartmentId).Id();
    }
}