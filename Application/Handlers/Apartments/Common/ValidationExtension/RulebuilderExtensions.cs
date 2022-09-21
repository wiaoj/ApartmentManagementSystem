using Domain.Enums;
using FluentValidation;
using ApartmentState = Domain.Enums.ApartmentState;

namespace Application.Handlers.Apartments.Common.ValidationExtension;
internal static class RuleBuilderExtensions {
    public static IRuleBuilder<T, Guid> Id<T>(this IRuleBuilder<T, Guid> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }

    public static IRuleBuilder<T, ApartmentState> ApartmentState<T>(this IRuleBuilder<T, ApartmentState> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .IsInEnum();
        return options;
    }

    public static IRuleBuilder<T, String> Number<T>(this IRuleBuilder<T, String> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }

    public static IRuleBuilder<T, String> BlockNo<T>(this IRuleBuilder<T, String> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }

    public static IRuleBuilder<T, String> Floor<T>(this IRuleBuilder<T, String> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }

    public static IRuleBuilder<T, String> Type<T>(this IRuleBuilder<T, String> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }
}