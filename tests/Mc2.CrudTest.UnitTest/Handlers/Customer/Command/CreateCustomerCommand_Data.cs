
using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;

using System.Collections;

namespace Mc2.CrudTest.UnitTest.Handlers.Customer.Command;

public class CreateCustomerCommand_Data
{
    public static IEnumerable<object[]> SetDataFor_CreateCustomer_WithEverythingIsOk()
    {
        yield return new object[] { new CreateCustomerCommand() {
            Firstname = "Yasin",
            Lastname = "Asadnezhad",
            Email = "yasin@gmail.com",
            PhoneNumber = "+989306030638",
            BankAccountNumber= "6280231377560890",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    public static IEnumerable<object[]> SetDataFor_CreateCustomer_WithFirstnameIsEmpty_ShouldBeFailed()
    {
        yield return new object[] { new CreateCustomerCommand() {
            Firstname = "",
            Lastname = "Asadnezhad",
            Email = "yasin@gmail.com",
            PhoneNumber = "+989306030638",
            BankAccountNumber= "6280231377560890",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    
    public static IEnumerable<object[]> SetDataFor_Check_PhoneNumberIsMobile_ShouldBeSuccess()
    {
        yield return new object[] { new CreateCustomerCommand() {
            Firstname = "Yasin",
            Lastname = "Asadnezhad",
            Email = "yasin@gmail.com",
            PhoneNumber = "+989121234567",
            BankAccountNumber= "6280231377560890",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    public static IEnumerable<object[]> SetDataFor_Check_PhoneNumberIsMobile_ShouldBeFaild()
    {
        yield return new object[] { new CreateCustomerCommand() {
            Firstname = "Yasin",
            Lastname = "Asadnezhad",
            Email = "yasin@gmail.com",
            PhoneNumber = "+982188776655",
            BankAccountNumber= "6280231377560890",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    public static IEnumerable<object[]> SetDataFor_CreateCustomer_WithLastnameIsEmpty_ShouldBeFailed()
    {
        yield return new object[] { new CreateCustomerCommand() {
            Firstname = "Yasin",
            Lastname = "",
            Email = "yasin@gmail.com",
            PhoneNumber = "+989306030638",
            BankAccountNumber= "6280231377560890",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    public static IEnumerable<object[]> SetDataFor_CreateCustomer_WithBankAccountNumberIsNotValid()
    {
        yield return new object[] { new CreateCustomerCommand() {
             Firstname = "Yasin",
            Lastname = "Asadnezhad",
            Email = "yasin@gmail.com",
            PhoneNumber = "+989306030638",
            BankAccountNumber = "6219",
            DateOfBirth = DateTime.Now,
        }
    };
    }

    public static IEnumerable<object[]> SetDataFor_CreateCustomer_WithEmailIsNotValid()
    {
        yield return new object[] { new CreateCustomerCommand() {
             Firstname = "Yasin",
            Lastname = "Asadnezhad",
            Email = "yasin",
            PhoneNumber = "+989306030638",
            BankAccountNumber= "6280231377560890",
            DateOfBirth = DateTime.Now,
        }
    };
    }
    
    public static IEnumerable<object[]> SetDataFor_CreateCustomer_WithEmailExistsBefore()
    {
        yield return new object[] { new CreateCustomerCommand() {
            Firstname = "Yasin",
            Lastname = "Asadnezhad",
            Email = "yasin@gmail.com",
            PhoneNumber = "+989306030638",
            BankAccountNumber= "6280231377560890",
            DateOfBirth = DateTime.Now,
        }
    };
    }

}
