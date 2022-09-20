using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class ApartmentRepository : Repository<Apartment>, IApartmentRepository {
    public ApartmentRepository(ApartmentManagementSystemDbContext context) : base(context) { }
}