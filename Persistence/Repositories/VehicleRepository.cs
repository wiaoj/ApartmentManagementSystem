using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class VehicleRepository : Repository<Vehicle>, IVehicleRepository {
    public VehicleRepository(ApartmentManagementSystemDbContext context) : base(context) { }
}