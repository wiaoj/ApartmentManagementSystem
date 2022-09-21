using Application.Repositories.Base;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories.Base;
public class Repository<TypeEntity> : IRepository<TypeEntity> where TypeEntity : IBaseEntity, new() {
    private readonly ApartmentManagementSystemDbContext _context;
    public Repository(ApartmentManagementSystemDbContext context) => this._context = context;

    public DbSet<TypeEntity> Table => _context.Set<TypeEntity>();

    private async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    public async Task<TypeEntity> AddAsync(TypeEntity entity) {
        await Table.AddAsync(entity);
        await SaveChangesAsync();
        return entity;
    }

    public async Task<ICollection<TypeEntity>> AddRangeAsync(ICollection<TypeEntity> entities) {
        await Table.AddRangeAsync(entities);
        await SaveChangesAsync();
        return entities;
    }

    public async Task<TypeEntity> DeleteAsync(TypeEntity entity) {
        return await Task.Run(async () => {
            Table.Remove(entity);
            await SaveChangesAsync();
            return entity;
        });
    }

    public async Task<TypeEntity> DeleteAsync(Guid id) {
        return await Task.Run(async () => {
            TypeEntity? entity = await GetByIdAsync(id, enableTracking: true);
            Table.Remove(entity);
            await SaveChangesAsync();
            return entity;
        });
    }

    public async Task<ICollection<TypeEntity>> DeleteRangeAsync(ICollection<TypeEntity> entities) {
        return await Task.Run(async () => {
            Table.RemoveRange(entities);
            await SaveChangesAsync();
            return entities;
        });
    }

    public IQueryable<TypeEntity> GetAll(Boolean enableTracking) {
        IQueryable<TypeEntity> query = Table.AsQueryable();
        return enableTracking ? query : query.AsNoTracking();
    }

    public async Task<TypeEntity?> GetByIdAsync(Guid id, Boolean enableTracking) {
        return enableTracking ? await Table.FindAsync(id) : await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<TypeEntity?> GetByIdAsync(Guid id,
        Func<IQueryable<TypeEntity>, IIncludableQueryable<TypeEntity, Object>>? include = null,
        Boolean enableTracking = true) {

        var entity = Table.AsQueryable();
        if(enableTracking is false)
            entity = entity.AsNoTracking();
        if(include is not null)
            entity = include(entity);
        return await entity.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<TypeEntity?> GetSingleAsync(Expression<Func<TypeEntity, Boolean>> expression, Boolean enableTracking) {
        return await Task.Run(() => {
            IQueryable<TypeEntity> query = Table.AsQueryable();
            return enableTracking ?
                query.SingleOrDefaultAsync(expression) :
                query.AsNoTracking().SingleOrDefaultAsync(expression);
        });
    }

    public async Task<IQueryable<TypeEntity>> GetWhereAsync(Expression<Func<TypeEntity, Boolean>> expression, Boolean enableTracking) {
        return await Task.Run(() => {
            IQueryable<TypeEntity> query = Table.Where(expression);
            return enableTracking ? query : query.AsNoTracking();
        });
    }

    public async Task<TypeEntity> UpdateAsync(TypeEntity entity) {
        return await Task.Run(async () => {
            Table.Update(entity);
            await SaveChangesAsync();
            return entity;
        });
    }
}