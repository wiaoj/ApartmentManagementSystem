using Application.Handlers.Phonenumbers.BusinessRules;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;
public static class ServiceRegistration {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());


        services.AddScoped<PhoneNumberBusinessRules>();
        return services;
    }
}