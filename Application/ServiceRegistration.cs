using Application.Handlers.Bills.BusinessRules;
using Application.Handlers.PhoneNumbers.BusinessRules;
using Application.Handlers.Users.BusinessRules;
using Application.Handlers.Vehicles.BusinessRules;
using Application.Pipelines;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;
public static class ServiceRegistration {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        services.AddScoped<PhoneNumberBusinessRules>();
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<VehicleBusinessRules>();
        services.AddScoped<BillBusinessRules>();
        return services;
    }
}