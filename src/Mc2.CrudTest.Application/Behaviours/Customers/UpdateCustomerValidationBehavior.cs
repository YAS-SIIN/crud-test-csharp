
using FluentValidation.Results;

using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;

using MediatR;
 

namespace Mc2.CrudTest.Application.Behaviors.Customers;

public class UpdateCustomerValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<UpdateCustomerCommand, ResultDto<ValidationResult>>
{
  
    public async Task<ResultDto<ValidationResult>> Handle(UpdateCustomerCommand request, RequestHandlerDelegate<ResultDto<ValidationResult>> next, CancellationToken cancellationToken)
    {
        // Validation
        var validation = new UpdateCustomerCommandValidator().Validate(request);
        if (!validation.IsValid)
            return ResultDto<ValidationResult>.ReturnData(EnumResponses.Success, validation);

        return await next();
    }
}
