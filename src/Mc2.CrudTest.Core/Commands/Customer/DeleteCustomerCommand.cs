
using FluentValidation;

using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;

using MediatR;

using System.ComponentModel;

namespace Mc2.CrudTest.Core.Commands.Customer;

public class DeleteCustomerCommand : IRequest<ResultDto<int>>
{
    /// <summary>
    /// Customer Id
    /// </summary> 
    public int Id { get; set; }
     
}


public class DeleteCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {

        RuleFor(v => v.Id).NotNull().WithMessage("Enter {PropertyName}.");
         
    }

}