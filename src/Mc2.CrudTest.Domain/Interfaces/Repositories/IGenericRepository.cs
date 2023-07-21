
using System.Linq.Expressions;

namespace Mc2.CrudTest.Domain.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class
{

    bool ExistData(Expression<Func<T, bool>> predicate = null);
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    T? GetById(object id);
    object Get(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, object>>? select = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    void Add(T entity, bool save = false);
    void AddRange(List<T> entityList, bool save = false);
    void Update(T entity, bool save = false);
    void UpdateRange(List<T> entity, bool save = false);
    void Delete(T entity, bool save = false);
    void DeleteRange(List<T> entity, bool save = false);

    //--------

    Task<bool> ExistDataAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> predicate = null);
    Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken);
    Task<object> GetAsync(CancellationToken cancellationToken, Expression<Func<T, bool>>? predicate = null, Expression<Func<T, object>>? select = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    Task AddAsync(T entity, CancellationToken cancellationToken, bool save = false);
    Task AddRangeAsync(List<T> entityList, CancellationToken cancellationToken, bool save = false);
    void SaveChanges();
    Task SaveChangesAsync(CancellationToken cancellationToken);

}
