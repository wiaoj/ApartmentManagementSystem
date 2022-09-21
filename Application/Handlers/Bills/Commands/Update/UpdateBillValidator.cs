using Application.Handlers.Bills.Common.ValidationExtension;
using Domain.Enums;
using FluentValidation;

namespace Application.Handlers.Bills.Commands.Update;
public class UpdateBillValidator : AbstractValidator<UpdateBillCommand> {
    public UpdateBillValidator() {
        RuleFor(x => x.Id).Id();
        RuleFor(x => x.UserId).Id();
        RuleFor(x => x.BillType).BillType();
        RuleFor(x => x.Month).Month();
        RuleFor(x => x.Price).Price();
        RuleFor(x => x.Description).Description();
        RuleFor(x => x.IsPaid).Paid();
    }
}