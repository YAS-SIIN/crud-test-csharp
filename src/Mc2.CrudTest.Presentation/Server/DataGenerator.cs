
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;

using Microsoft.EntityFrameworkCore;

using System.Data;
using System.Diagnostics;
using System.Text;

namespace Mc2.CrudTest.Presentation.Server;

public class DataGenerator
{
    /// <summary>
    /// Initializing new data
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        // Add new customer
        if (!_unitOfWork.GetRepository<Customer>().ExistData())
        {
            List<Customer> instruments = new () {
            new Customer { Firstname = "Yasin", Lastname = "Asadnezhad", DateOfBirth = new DateTime(1992,4,30), Email="y@y.com", PhoneNumber = 09353662294, BankAccountNumber = "6037" },
            new Customer { Firstname = "Sadegh", Lastname = "Asadnezhad", DateOfBirth = new DateTime(1994,2,15), Email="s@y.com", PhoneNumber = 09353662295, BankAccountNumber = "6219" }, 
            new Customer { Firstname = "Ali", Lastname = "Rahmani", DateOfBirth = new DateTime(1993,5,10), Email="a@y.com", PhoneNumber = 09353662296, BankAccountNumber = "5047" }, 
        };
            _unitOfWork.GetRepository<Customer>().AddRange(instruments, true);
        } 

    }
}
