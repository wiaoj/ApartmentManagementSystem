using Application.Handlers.Bills.Common.ValidationExtension;
using FluentValidation;

namespace Application.Handlers.Bills.Commands.Create;
public class CreateBillValidator : AbstractValidator<CreateBillCommand> {
    public CreateBillValidator() {
        RuleFor(x => x.UserId).Id();
        RuleFor(x => x.BillType).BillType();
        RuleFor(x => x.Month).Month();
        RuleFor(x => x.Price).Price();
        RuleFor(x => x.Description).Description();
        RuleFor(x => x.IsPaid).Paid();
    }
}