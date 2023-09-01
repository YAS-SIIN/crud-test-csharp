
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
            Id = 2,
            Firstname = "Mahdi",
            Lastname = "Asadnezhad",
            Email = "mahdi@gmail.com",
            PhoneNumber = "+989306030639",
            BankAccountNumber= "6280231377560890",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    public static IEnumerable<object[]> SetDataFor_UpdateCustomer_WithFirstnameIsEmpty_ShouldBeFailed()
    {
        yield return new object[] { new UpdateCustomerCommand() {
            Id = 2,
            Firstname = "",
            Lastname = "Asadnezhad",
            Email = "mahdi@gmail.com",
            PhoneNumber = "+989306030639",
            BankAccountNumber= "6280231377560890",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    public static IEnumerable<object[]> SetDataFor_UpdateCustomer_WithLastnameIsEmpty_ShouldBeFailed()
    {
        yield return new object[] { new UpdateCustomerCommand() {
            Id = 2,
            Firstname = "Mahdi",
            Lastname = "",
            Email = "mahdi@gmail.com",
            PhoneNumber = "+989306030639",
            BankAccountNumber= "6280231377560890",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    public static IEnumerable<object[]> SetDataFor_UpdateCustomer_WithBankAccountNumberIsNotValid()
    {
        yield return new object[] { new UpdateCustomerCommand() {
            Id = 2,
            Firstname = "Mahdi",
            Lastname = "Asadnezhad",
            Email = "mahdi@gmail.com",
            PhoneNumber = "+989306030639",
            BankAccountNumber = "6219",
            DateOfBirth = DateTime.Now,
        }
    };
    }

    public static IEnumerable<object[]> SetDataFor_UpdateCustomer_WithEmailIsNotValid()
    {
        yield return new object[] { new UpdateCustomerCommand() {
            Id = 2,
            Firstname = "Mahdi",
            Lastname = "Asadnezhad",
            Email = "mahdi",
            PhoneNumber = "+989306030639",
            BankAccountNumber= "6280231377560890",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    public static IEnumerable<object[]> SetDataFor_UpdateCustomer_WithEmailExistsBefore()
    {
        yield return new object[] { new UpdateCustomerCommand() {
            Id = 2,
            Firstname = "Mahdi",
            Lastname = "Asadnezhad",
            Email = "y@y.com",
            PhoneNumber = "+989306030639",
            BankAccountNumber= "6280231377560890",
            DateOfBirth = DateTime.Now,
        }
    };
    }

}
