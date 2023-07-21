
using FluentValidation;

using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;

using MediatR;

using PhoneNumbers;

using System.ComponentModel;

namespace Mc2.CrudTest.Core.Commands.Customer;

public class UpdateCustomerCommand : IRequest<ResultDto<GetCustomerResponse>>
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


public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {

        RuleFor(v => v.Firstname)
            .NotEmpty().WithMessage("Enter {PropertyName}.")
            .MaximumLength(50).WithMessage("Maximum size of {PropertyName} is {MaxLength}.")
            .MinimumLength(3).WithMessage("Minimum size of {PropertyName} is {MinLength}.");

        RuleFor(v => v.Lastname)
            .NotEmpty().WithMessage("Enter {PropertyName}.")
            .MaximumLength(100).WithMessage("Maximum size of {PropertyName} is {MaxLength}.")
            .MinimumLength(3).WithMessage("Minimum size of {PropertyName} is {MinLength}.");


        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Enter {PropertyName}.")
            .MaximumLength(15).WithMessage("Maximum size of {PropertyName} is {MaxLength}.")
            .Must(x => x.StartsWith("+") && PhoneNumberUtil.GetInstance()
                .IsValidNumber(PhoneNumberUtil.GetInstance().Parse(x, "")))
            .WithMessage("Enter Valid {PropertyName}.");

        RuleFor(x => x.BankAccountNumber)
            .CreditCard().WithMessage("Enter valid {PropertyName}.")
            .When(x => x.BankAccountNumber is not null);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Enter {PropertyName}.")
            .MaximumLength(100).WithMessage("Maximum size of {PropertyName} is {MaxLength}.")
            .MinimumLength(3).WithMessage("Minimum size of {PropertyName} is {MinLength}.")
            .EmailAddress().WithMessage("Enter valid {PropertyName}.");

        RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Enter {PropertyName}.");

    }

}