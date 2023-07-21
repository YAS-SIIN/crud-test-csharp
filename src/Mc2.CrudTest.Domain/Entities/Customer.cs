

using Mc2.CrudTest.Domain.Entities.Common;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain.Entities;

/// <summary>
/// Customer Entity
/// </summary>
public class Customer : BaseEntity<int>
{
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
    public ulong PhoneNumber { get; set; }

    /// <summary>
    /// Email of customer
    /// </summary>
    public string Email { get; set; }
     
    /// <summary>
    /// Bank account number of customer
    /// </summary>
    public string BankAccountNumber { get; set; }
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