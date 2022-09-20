using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories;
public class UserRepository : Repository<User>, IUserRepository {
    public UserRepository(ApartmentManagementSystemDbContext context) : base(context) { }
}