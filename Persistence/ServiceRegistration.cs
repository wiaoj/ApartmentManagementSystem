using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence;
public static class ServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<ApartmentManagementSystemDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApartmentManagementSystemConnectionString")));


        return services;
    }
}