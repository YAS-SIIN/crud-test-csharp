
using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;

using System.Collections;

namespace Mc2.CrudTest.UnitTest.Handlers.Customer.Command;

public class UpdateCustomerCommand_Data
{
    public static IEnumerable<object[]> SetDataFor_UpdateCustomer_WithEverythingIsOk()
    {
        yield return new object[] { new UpdateCustomerCommand() {
            Id = 1,
            Firstname = "YasinTest",
            Lastname = "Asadnezhad",
            Email = "yasin@gmail.com",
            PhoneNumber = "+989306030636",
            BankAccountNumber= "6219861904897732",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    public static IEnumerable<object[]> SetDataFor_UpdateCustomer_WithFirstnameIsEmpty_ShouldBeFailed()
    {
        yield return new object[] { new UpdateCustomerCommand() {
            Id = 1,
            Firstname = "",
            Lastname = "Asadnezhad",
            Email = "yasin@gmail.com",
            PhoneNumber = "+989306030636",
            BankAccountNumber= "6219861904897732",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    public static IEnumerable<object[]> SetDataFor_UpdateCustomer_WithLastnameIsEmpty_ShouldBeFailed()
    {
        yield return new object[] { new UpdateCustomerCommand() {
            Id = 1,
            Firstname = "Yasin",
            Lastname = "",
            Email = "yasin@gmail.com",
            PhoneNumber = "+989306030636",
            BankAccountNumber= "6219861904897732",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    public static IEnumerable<object[]> SetDataFor_UpdateCustomer_WithBankAccountNumberIsNotValid()
    {
        yield return new object[] { new UpdateCustomerCommand() {
            Id = 1,
             Firstname = "Yasin",
            Lastname = "Asadnezhad",
            Email = "yasin@gmail.com",
            PhoneNumber = "+989306030636",
            BankAccountNumber = "6219",
            DateOfBirth = DateTime.Now,
        }
    };
    }

    public static IEnumerable<object[]> SetDataFor_UpdateCustomer_WithEmailIsNotValid()
    {
        yield return new object[] { new UpdateCustomerCommand() {
             Firstname = "Yasin",
            Lastname = "Asadnezhad",
            Email = "yasin",
            PhoneNumber = "+989306030636",
            BankAccountNumber= "6219861904897732",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    public static IEnumerable<object[]> SetDataFor_UpdateCustomer_WithEmailExistsBefore()
    {
        yield return new object[] { new UpdateCustomerCommand() {
            Id = 1,
            Firstname = "Yasin",
            Lastname = "Asadnezhad",
            Email = "s@y.com",
            PhoneNumber = "+989306030636",
            BankAccountNumber= "6219861904897732",
            DateOfBirth = DateTime.Now,
        }
    };
    }

}
