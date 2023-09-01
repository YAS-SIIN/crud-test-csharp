using CleanArchitecture.Domain.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.ValueObjects;

public record CustomerRow
{ 
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime DateOfBirth { get; }
    public string PhoneNumber { get; }
    public string Email { get; }
    public string BankAccountNumber { get; }
    public CustomerRow(string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
    {
        if (string.IsNullOrWhiteSpace(firstname)) throw new Exception("First name is empty");
        if (firstname.Length < 3) throw new Exception("First name is invalid");
        if (string.IsNullOrWhiteSpace(lastname)) throw new Exception("Last name is empty");
        if (lastname.Length < 3) throw new Exception("Last name is invalid");

        FirstName = firstname;
        LastName = lastname;

        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }
 
}
