using Domain.Enums;
using FluentValidation;

namespace Application.Handlers.Bills.Common.ValidationExtension;
internal static class RuleBuilderExtensions {
    public static IRuleBuilder<T, Guid> Id<T>(this IRuleBuilder<T, Guid> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }

    public static IRuleBuilder<T, BillType> BillType<T>(this IRuleBuilder<T, BillType> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }

    public static IRuleBuilder<T, DateTime> Month<T>(this IRuleBuilder<T, DateTime> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .Must(x => x.Equals(DateTime.Now- new DateTime(DateTime.Now.Year,DateTime.Now.Month - 2, 1)));
        return options;
    }

    public static IRuleBuilder<T, Decimal> Price<T>(this IRuleBuilder<T, Decimal> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(Decimal.MaxValue);
        return options;
    }

    public static IRuleBuilder<T, String> Description<T>(this IRuleBuilder<T, String> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(256);
        return options;
    }

    public static IRuleBuilder<T, Boolean> Paid<T>(this IRuleBuilder<T, Boolean> ruleBuilder) {
        var options = ruleBuilder
            .NotNull();
        return options;
    }
}