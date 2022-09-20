using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;
public class ApartmentManagementSystemDbContext : DbContext {
    protected readonly IConfiguration Configuration;
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }


    public ApartmentManagementSystemDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions) {
        this.Configuration = configuration;
    }
}
