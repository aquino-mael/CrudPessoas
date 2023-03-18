using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly MyContext _context;
    private readonly DbSet<TEntity> _dataset;
    
    public BaseRepository(MyContext context)
    {
        _context = context;
        _dataset = context.Set<TEntity>();
    }
    
    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        try
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

            entity.CreatedAt = DateTime.UtcNow;

            _dataset.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<TEntity?> UpdateAsync(TEntity entity)
    {
        try
        {
            var itemExist = await ExistAsync(entity.Id);

            if (!itemExist)
            {
                return null;
            }

            var result = await _dataset.SingleOrDefaultAsync(
                p => p.Id.Equals(entity.Id)
            );

            if (result == null)
            {
                return null;
            }

            entity.UpdatedAt = DateTime.UtcNow;
            entity.CreatedAt = result.CreatedAt;

            _dataset.Entry(result).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var itemExist = await ExistAsync(id);

            if (!itemExist)
            {
                return false;
            }

            var result = await _dataset.SingleOrDefaultAsync(
                p => p.Id.Equals(id)
            );

            _dataset.Remove(result!);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<TEntity?> SelectAsync(Guid id)
    {
        try
        {
            var itemExist = await ExistAsync(id);

            if (!itemExist)
            {
                return null;
            }

            return await _dataset.SingleOrDefaultAsync(
                p => p.Id.Equals(id)
            );
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<TEntity>?> SelectAsync()
    {
        try
        {
            return await _dataset.ToListAsync();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> ExistAsync(Guid id)
    {
        return await _dataset.AnyAsync(p => p.Id.Equals(id));
    }
}