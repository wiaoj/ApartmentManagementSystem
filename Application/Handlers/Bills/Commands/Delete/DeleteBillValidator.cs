using Application.Handlers.Bills.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.Bills.Commands.Delete;
public class DeleteBillValidator : AbstractValidator<DeleteBillCommand> {
    public DeleteBillValidator() {
        RuleFor(x => x.Id).Id();
    }
}