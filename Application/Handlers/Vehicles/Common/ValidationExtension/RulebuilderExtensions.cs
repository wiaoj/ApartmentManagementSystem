using FluentValidation;

namespace Application.Handlers.Vehicles.Common.ValidationExtension;
internal static class RuleBuilderExtensions {
    public static IRuleBuilder<T, Guid> Id<T>(this IRuleBuilder<T, Guid> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }
    public static IRuleBuilder<T, String> Plate<T>(this IRuleBuilder<T, String> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }
}