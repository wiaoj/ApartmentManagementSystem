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


    //protected override void OnModelCreating(ModelBuilder modelBuilder) {
    //    modelBuilder.Entity<User>(x => {
    //        x.ToTable("Users").HasKey(k => k.Id);

    //        {
    //            x.HasOne(p => p.Apartment);
    //            x.Property(p => p.ApartmentId).HasColumnName("ApartmentId");
    //        }
    //    });

    //    modelBuilder.Entity<Apartment>(x => {
    //        x.ToTable("Apartments").HasKey(k => k.Id);

    //        //{
    //        //    x.HasOne(p => p.User);
    //        //    x.Property(p => p.UserId).HasColumnName("UserId");
    //        //}
    //    });
    //}
}
