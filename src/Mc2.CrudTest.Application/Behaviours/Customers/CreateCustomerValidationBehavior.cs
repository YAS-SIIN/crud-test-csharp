
using FluentValidation.Results;

using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;

using MediatR;

namespace Mc2.CrudTest.Application.Behaviors.Customers;

public class CreateCustomerValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<CreateCustomerCommand, ResultDto<ValidationResult>>
{
    public async Task<ResultDto<ValidationResult>> Handle(CreateCustomerCommand request, RequestHandlerDelegate<ResultDto<ValidationResult>> next, CancellationToken cancellationToken)
    {
        // Validation
        var validation = new CreateCustomerCommandValidator().Validate(request);
        if (!validation.IsValid)
            return ResultDto<ValidationResult>.ReturnData(EnumResponses.Success, validation);

        return await next();
    }
 
}
