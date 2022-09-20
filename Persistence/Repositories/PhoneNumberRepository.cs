using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;

public class PhoneNumberRepository : Repository<PhoneNumber>, IPhoneNumberRepository {
    public PhoneNumberRepository(ApartmentManagementSystemDbContext context) : base(context) { }
}
