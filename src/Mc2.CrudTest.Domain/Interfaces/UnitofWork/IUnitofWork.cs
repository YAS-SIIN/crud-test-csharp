 

using Mc2.CrudTest.Interfaces.Repositories;
                
namespace Mc2.CrudTest.Interfaces.UnitOfWork;

public interface IUnitOfWork 
{
    IGenericRepository<T> GetRepository<T>() where T : class;
    void Dispose();
}
