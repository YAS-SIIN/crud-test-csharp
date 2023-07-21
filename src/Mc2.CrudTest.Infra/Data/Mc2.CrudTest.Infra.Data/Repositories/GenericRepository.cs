
using Mc2.CrudTest.Domain.Interfaces.Repositories;
using Mc2.CrudTest.Infra.Data.Context;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace Mc2.CrudTest.Infra.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{

    private readonly Mc2CrudTestDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(Mc2CrudTestDbContext context)
    {
        _context = context; 
        _dbSet = _context.Set<T>();
    }

    public bool ExistData()
    {
        return _dbSet.Any();
    }

    public bool ExistData(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).Any();
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet;
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public T? GetById(object id)
    {
        return _dbSet.Find(id); 
    }


    public object Get(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, object>>? select = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        IQueryable<T> data = _dbSet;
        if (predicate is not null)
        {
            data = data.Where(predicate).AsQueryable();
        }
        else if (orderBy is not null)
        {
            data = orderBy(data);
        }
        else if (select is not null)
        {
            return data.Select(select).ToList();
        }
        return data.ToList();
    }

    public virtual void Add(T entity, bool save = false)
    {
        _dbSet.Add(entity);
        if (save) SaveChanges();
    }

    public virtual void AddRange(List<T> entityList, bool save = false)
    {
        _dbSet.AddRange(entityList);
        if (save) SaveChanges();
    }

    public virtual void Update(T entity, bool save = false)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        if (save) SaveChanges();
    }

    public virtual void UpdateRange(List<T> entity, bool save = false)
    {
        _dbSet.AttachRange(entity);
        _context.Entry(entity).State = EntityState.Modified;
        if (save) SaveChanges();
    }


    public virtual void Delete(T entity, bool save = false)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
            _dbSet.Attach(entity);
        _dbSet.Remove(entity);
        if (save) SaveChanges();
    }

    public virtual void DeleteRange(List<T> entity, bool save = false)
    {
        _dbSet.RemoveRange(entity);
        if (save) SaveChanges();
    }


    //--------------
    #region Async Methods

    public async Task<bool> ExistDataAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(cancellationToken);
    }
    public async Task<bool> ExistDataAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.Where(predicate).AnyAsync(cancellationToken);
    }

    public async Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        var data = await _dbSet.ToListAsync(cancellationToken);
        return data.AsQueryable();
    }
    public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        var data = await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        return data.AsQueryable();
    }

    public async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task<object> GetAsync(CancellationToken cancellationToken, Expression<Func<T, bool>>? predicate = null, Expression<Func<T, object>>? select = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        IQueryable<T> data = _dbSet;
        if (predicate is not null)
        {
           data = data.Where(predicate).AsQueryable();
        }
        else if (orderBy is not null)
        {
            data = orderBy(data);
        }
        else if (select is not null)
        {
           return await data.Select(select).ToListAsync(cancellationToken);
        }
        return await data.ToListAsync(cancellationToken);
    }

    public async virtual Task AddAsync(T entity, CancellationToken cancellationToken, bool save = false)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        if (save) await SaveChangesAsync(cancellationToken);
    }

    public async virtual Task AddRangeAsync(List<T> entityList, CancellationToken cancellationToken, bool save = false)
    {
        await _dbSet.AddRangeAsync(entityList, cancellationToken);
        if (save) await SaveChangesAsync(cancellationToken);
    }

    #endregion
    /// <summary>
    /// Save and commit changes in database
    /// </summary>
    public void SaveChanges()
    {
        try
        {
            _context.SaveChanges();
        }
        catch {}
    }

    /// <summary>
    /// Save and commit changes in database using multithread
    /// </summary>
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch {}
    }

}
