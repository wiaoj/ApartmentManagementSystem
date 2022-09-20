using Application.Repositories.Base;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories.Base;
public class Repository<TypeEntity> : IRepository<TypeEntity> where TypeEntity : IBaseEntity, new() {
    public DbSet<TypeEntity> Table => throw new NotImplementedException();

    public Task<Boolean> AddAsync(TypeEntity entity) => throw new NotImplementedException();
    public Task<Boolean> AddRangeAsync(ICollection<TypeEntity> entities) => throw new NotImplementedException();
    public Task<Boolean> DeleteAsync(TypeEntity entity) => throw new NotImplementedException();
    public Task<Boolean> DeleteAsync(Guid id) => throw new NotImplementedException();
    public Task<Boolean> DeleteRangeAsync(ICollection<TypeEntity> entities) => throw new NotImplementedException();
    public IQueryable<TypeEntity> GetAll(Boolean tracking) => throw new NotImplementedException();
    public Task<TypeEntity> GetByIdAsync(Guid id, Boolean tracking) => throw new NotImplementedException();
    public Task<TypeEntity> GetSingleAsync(Expression<Func<TypeEntity, Boolean>> expression, Boolean tracking) => throw new NotImplementedException();
    public Task<IQueryable<TypeEntity>> GetWhereAsync(Expression<Func<TypeEntity, Boolean>> expression, Boolean tracking) => throw new NotImplementedException();
    public Task<Boolean> UpdateAsync(TypeEntity entity) => throw new NotImplementedException();
}