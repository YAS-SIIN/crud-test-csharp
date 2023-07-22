using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Enums;
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
    public static DbContextOptions<Mc2CrudTestDbContext>? contextOptions;
    public static Mc2CrudTestDbContext? dbContext;
    public static Mock<UnitOfWork>? mockUnitOfWork;

    public static void Initialize()
    {
        InitializeDBContext();
        InitializeData();
    }

    /// <summary>
    /// Inject DbContext
    /// </summary>
    public static void InitializeDBContext()
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<Mc2CrudTestDbContext>();
        dbContextOptionsBuilder.UseInMemoryDatabase("Mc2CrudTestDbContext");
        contextOptions = dbContextOptionsBuilder.Options;
        dbContext = new Mc2CrudTestDbContext(contextOptions);
        mockUnitOfWork = new Mock<UnitOfWork>(dbContext);
    }
    /// <summary>
    /// Initializing new data
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static void InitializeData()
    {
        var _unitOfWork = new UnitOfWork(dbContext);

        // Add new customer

        List<Customer> instruments = new() {
        new Customer { Firstname = "Yasin", Lastname = "Asadnezhad", DateOfBirth = new DateTime(1992,4,30), Email="y@y.com", PhoneNumber = "09353662281", BankAccountNumber = "6280231377560890" },
        new Customer { Firstname = "Sadegh", Lastname = "Asadnezhad", DateOfBirth = new DateTime(1994,2,15), Email="s@y.com", PhoneNumber = "09353662295", BankAccountNumber = "6280231377560890" },
        new Customer { Firstname = "Ali", Lastname = "Rahmani", DateOfBirth = new DateTime(1993,5,10), Email="a@y.com", PhoneNumber = "09353662296", BankAccountNumber = "6280231377560890" },
    };
        _unitOfWork.GetRepository<Customer>().AddRange(instruments, true);


    }
}
