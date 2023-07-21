
using FluentValidation;

using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;

using MediatR;

using System.ComponentModel;

namespace Mc2.CrudTest.Core.Commands.Customer;

public class CreateCustomerCommand : IRequest<ResultDto<GetCustomerResponse>>
{
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
    public ulong? PhoneNumber { get; set; }

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


public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {

        RuleFor(v => v.Firstname)
            .NotEmpty().WithMessage("Enter {PropertyName}.")
            .MaximumLength(50).WithMessage("Maximum size of {PropertyName} is {MaxLength}.")
            .MinimumLength(3).WithMessage("Minimum size of {PropertyName} is {MinLength}.");

        RuleFor(v => v.Lastname)
            .NotEmpty().WithMessage("Enter {PropertyName}.")
            .MaximumLength(100).WithMessage("Maximum size of {PropertyName} is {MaxLength}.")
            .MinimumLength(3).WithMessage("Minimum size of {PropertyName} is {MinLength}.");


    }

}