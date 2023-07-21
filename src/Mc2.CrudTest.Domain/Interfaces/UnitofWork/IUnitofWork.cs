

using Mc2.CrudTest.Domain.Interfaces.Repositories;
                
namespace Mc2.CrudTest.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork 
{
    IGenericRepository<T> GetRepository<T>() where T : class;
    void Dispose();
}
