using FluentValidation;

namespace Application.Handlers.Phonenumbers.Common.ValidationExtension;
internal static class RuleBuilderExtensions {
    public static IRuleBuilder<T, Guid> Id<T>(this IRuleBuilder<T, Guid> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }

    public static IRuleBuilder<T, String> CountryCode<T>(this IRuleBuilder<T, String> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(3);
        return options;
    }

    public static IRuleBuilder<T, String> Number<T>(this IRuleBuilder<T, String> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(10);
        return options;
    }
}