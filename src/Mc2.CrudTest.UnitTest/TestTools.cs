using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Infra.Data.Context;
using Mc2.CrudTest.Infra.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.UnitTest
{
    public static class TestTools
    { 
        public static DbContextOptions<Mc2CrudTestDbContext>? contextOptions;
        public static Mc2CrudTestDbContext? dbContext;
        public static Mock<UnitOfWork>? mockUnitOfWork;
        public static void DbConnection()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<Mc2CrudTestDbContext>();
            dbContextOptionsBuilder.UseInMemoryDatabase("Mc2CrudTestDbContext");
            contextOptions = dbContextOptionsBuilder.Options;
            dbContext = new Mc2CrudTestDbContext(contextOptions);
            mockUnitOfWork = new Mock<UnitOfWork>(dbContext);  
        }
         
    }
}
