using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Repositories.Base;
public interface IRepository<TypeEntity> where TypeEntity : IBaseEntity, new() {
    DbSet<TypeEntity> Table { get; }

    IQueryable<TypeEntity> GetAll(Boolean tracking);

    Task<IQueryable<TypeEntity>> GetWhereAsync(Expression<Func<TypeEntity, Boolean>> expression, Boolean tracking);
    Task<TypeEntity> GetSingleAsync(Expression<Func<TypeEntity, Boolean>> expression, Boolean tracking);
    Task<TypeEntity> GetByIdAsync(Guid id, Boolean tracking);


    Task<Boolean> AddAsync(TypeEntity entity);
    Task<Boolean> AddRangeAsync(ICollection<TypeEntity> entities);
    Task<Boolean> DeleteAsync(TypeEntity entity);
    Task<Boolean> DeleteRangeAsync(ICollection<TypeEntity> entities);
    Task<Boolean> DeleteAsync(Guid id);
    Task<Boolean> UpdateAsync(TypeEntity entity);
}