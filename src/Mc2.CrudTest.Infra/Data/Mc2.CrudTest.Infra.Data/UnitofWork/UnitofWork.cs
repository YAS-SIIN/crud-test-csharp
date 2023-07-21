

using Mc2.CrudTest.Domain.Interfaces.Repositories;
using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;
using Mc2.CrudTest.Infra.Data.Context;
using Mc2.CrudTest.Infra.Data.Repositories;
namespace Mc2.CrudTest.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly Mc2CrudTestDbContext _context;
    private bool disposed = false;

    public UnitOfWork(Mc2CrudTestDbContext context)
    {

      // Database.SetInitializer<MyDataBase>(null);
        if (context == null)
            throw new ArgumentException("DB context is null!");
        _context = context;              
    }


    /// <summary>
    /// Generate Repository of Entities
    /// </summary>
    /// <returns></returns>
    public IGenericRepository<T> GetRepository<T>() where T : class
    {                                     
        return new GenericRepository<T>(_context);
    }



    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


}
