using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application.Repositories.Base;
public interface IRepository<TypeEntity> where TypeEntity : IBaseEntity, new() {
    DbSet<TypeEntity> Table { get; }

    IQueryable<TypeEntity> GetAll(Boolean enableTracking);

    Task<IQueryable<TypeEntity>> GetWhereAsync(Expression<Func<TypeEntity, Boolean>> expression, Boolean enableTracking);
    Task<TypeEntity?> GetSingleAsync(Expression<Func<TypeEntity, Boolean>> expression, Boolean enableTracking);
    Task<TypeEntity?> GetByIdAsync(Guid id, Boolean enableTracking);


    Task<TypeEntity> AddAsync(TypeEntity entity);
    Task<ICollection<TypeEntity>> AddRangeAsync(ICollection<TypeEntity> entities);
    Task<TypeEntity> DeleteAsync(TypeEntity entity);
    Task<ICollection<TypeEntity>> DeleteRangeAsync(ICollection<TypeEntity> entities);
    Task<TypeEntity> DeleteAsync(Guid id);
    Task<TypeEntity> UpdateAsync(TypeEntity entity);
}