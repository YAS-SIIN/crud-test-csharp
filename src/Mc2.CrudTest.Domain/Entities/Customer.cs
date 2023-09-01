

using Mc2.CrudTest.Domain.Common;
using Mc2.CrudTest.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain.Entities;

/// <summary>
/// Customer Entity
/// </summary>
public class Customer : BaseEntity<int>
{
    public Customer() { }
    /// <summary>
    /// First name of customer
    /// </summary>
    public string Firstname { get; set; }

    /// <summary>
    /// Last name of customer
    /// </summary>
    public string Lastname { get; set; }

    /// <summary>
    /// Date of birth of customer
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Phone number of customer
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Email of customer
    /// </summary>
    public string Email { get; set; }
     
    /// <summary>
    /// Bank account number of customer
    /// </summary>
    public string BankAccountNumber { get; set; }

    public CustomerName customerName { get; }


    public Customer(string firstname, string lastname, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
    {
        if (string.IsNullOrWhiteSpace(firstname)) throw new ArgumentNullException(nameof(firstname));
        if (firstname.Length < 3) throw new ApplicationException("First name is invalid");

        if (string.IsNullOrWhiteSpace(lastname)) throw new ArgumentNullException(nameof(lastname));
        if (lastname.Length < 3) throw new ApplicationException("Last name is invalid");

        if (string.IsNullOrWhiteSpace(phoneNumber)) throw new ArgumentNullException(nameof(phoneNumber));
        if (phoneNumber.Length < 10) throw new ApplicationException("Phone number is invalid");

        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
        if (phoneNumber.Length < 4) throw new ApplicationException("Email is invalid");

        if (string.IsNullOrWhiteSpace(bankAccountNumber)) throw new ArgumentNullException(nameof(bankAccountNumber));
        if (bankAccountNumber.Length < 4) throw new ApplicationException("Bank account number is invalid");

        Firstname = firstname;
        Lastname = lastname;
        customerName = new CustomerName(firstname, lastname);
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        Email = email;
        BankAccountNumber = bankAccountNumber;
    }

}

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(b => b.Firstname).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Lastname).IsRequired().HasMaxLength(100); 
        builder.Property(b => b.DateOfBirth).IsRequired();
        builder.Property(b => b.PhoneNumber).IsRequired().HasMaxLength(15);
        builder.Property(b => b.Email).IsRequired().HasMaxLength(100);
        builder.Property(b => b.BankAccountNumber).IsRequired().HasMaxLength(100);

    }
}