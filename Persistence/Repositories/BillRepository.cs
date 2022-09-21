using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class BillRepository : Repository<Bill>, IBillRepository {
    public BillRepository(ApartmentManagementSystemDbContext context) : base(context) { }
}