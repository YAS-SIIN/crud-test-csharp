using Mc2.CrudTest.Domain.Entities; 
using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;
using Mc2.CrudTest.Infra.Data.Context;
using Mc2.CrudTest.Infra.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Shared.Tools;

public static class TestTools
{ 
    public static Mc2CrudTestDbContext? _dbContext;
    public static Mock<UnitOfWork>? _mockUnitOfWork;

    public static void Initialize()
    {
        InitializeDBContext();
        SeedData();
    }

    /// <summary>
    /// Inject DbContext
    /// </summary>
    public static void InitializeDBContext()
    {
        DbContextOptionsBuilder<Mc2CrudTestDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<Mc2CrudTestDbContext>(); 
        dbContextOptionsBuilder.UseInMemoryDatabase("Mc2CrudTestDbContext");
        DbContextOptions<Mc2CrudTestDbContext>? contextOptions = dbContextOptionsBuilder.Options;
        _dbContext = new Mc2CrudTestDbContext(contextOptions);
        _mockUnitOfWork = new Mock<UnitOfWork>(_dbContext);
    }
    /// <summary>
    /// Initializing new data
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static void SeedData()
    {
        //var _unitOfWork = new UnitOfWork(_dbContext);

        // Add new customer

        List<Customer> customers = new() {
        new Customer { Firstname = "Yasin", Lastname = "Asadnezhad", DateOfBirth = new DateTime(1992,4,30), Email="y@y.com", PhoneNumber = "09353662281", BankAccountNumber = "6280231377560890" },
        new Customer { Firstname = "Sadegh", Lastname = "Asadnezhad", DateOfBirth = new DateTime(1994,2,15), Email="s@y.com", PhoneNumber = "09353662295", BankAccountNumber = "6280231377560890" },
        new Customer { Firstname = "Ali", Lastname = "Rahmani", DateOfBirth = new DateTime(1993,5,10), Email="a@y.com", PhoneNumber = "09353662296", BankAccountNumber = "6280231377560890" },
        new Customer { Firstname = "Reza", Lastname = "Bahreini", DateOfBirth = new DateTime(1993,5,10), Email="r@y.com", PhoneNumber = "09353662297", BankAccountNumber = "6280231377560890" },
        new Customer { Firstname = "Reyhaneh", Lastname = "Sadafi", DateOfBirth = new DateTime(1993,5,10), Email="q@y.com", PhoneNumber = "09353662297", BankAccountNumber = "6280231377560890" },
        new Customer { Firstname = "Zhale", Lastname = "Teymoury", DateOfBirth = new DateTime(1993,5,10), Email="z@y.com", PhoneNumber = "09353662297", BankAccountNumber = "6280231377560890" },
    };
        _mockUnitOfWork.Object.GetRepository<Customer>().AddRange(customers, true);

        _mockUnitOfWork.Object.Dispose();
    }
}
