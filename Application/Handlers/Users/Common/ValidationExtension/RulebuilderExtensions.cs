using FluentValidation;

namespace Application.Handlers.Users.Common.ValidationExtension;
internal static class RuleBuilderExtensions {
    public static IRuleBuilder<T, Guid> Id<T>(this IRuleBuilder<T, Guid> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty();
        return options;
    }
    
    public static IRuleBuilder<T, String> FirstName<T>(this IRuleBuilder<T, String> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(64);
        return options;
    }
    
    public static IRuleBuilder<T, String> LastName<T>(this IRuleBuilder<T, String> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(64);
        return options;
    }

    public static IRuleBuilder<T, String> IdentityNumber<T>(this IRuleBuilder<T, String> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .MinimumLength(11)
            .MaximumLength(11);
        return options;
    }

    public static IRuleBuilder<T, String> Email<T>(this IRuleBuilder<T, String> ruleBuilder) {
        var options = ruleBuilder
            .NotNull()
            .NotEmpty()
            .EmailAddress();
        return options;
    }

    public static IRuleBuilder<T, Boolean> Tenant<T>(this IRuleBuilder<T, Boolean> ruleBuilder) {
        var options = ruleBuilder
            .NotNull();
        return options;
    }
}