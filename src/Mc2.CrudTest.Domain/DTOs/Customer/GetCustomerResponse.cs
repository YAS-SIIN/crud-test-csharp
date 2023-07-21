
using System.ComponentModel;

namespace Mc2.CrudTest.Domain.DTOs.Customer;

public class GetCustomerResponse
{
    /// <summary>
    /// Customer Id
    /// </summary> 
    public int Id { get; set; }

    /// <summary>
    /// First name of customer
    /// </summary>
    [DisplayName("First name")]
    public string? Firstname { get; set; }

    /// <summary>
    /// Last name of customer
    /// </summary>
    [DisplayName("Last name")]
    public string? Lastname { get; set; }

    /// <summary>
    /// Date of birth of customer
    /// </summary>
    [DisplayName("Date of birth")]
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// Phone number of customer
    /// </summary>
    [DisplayName("Phone numberh")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Email of customer
    /// </summary>
    [DisplayName("Email")]
    public string? Email { get; set; }

    /// <summary>
    /// Bank account number of customer
    /// </summary>
    [DisplayName("Bank account number")]
    public string? BankAccountNumber { get; set; }
}
