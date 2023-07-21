using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using System.Text.Json;

using MediatR;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Domain.DTOs;

namespace Mc2.CrudTest.Presentation.Shared.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{

    public UnhandledExceptionBehaviour()
    {
    }
         
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;
           // await HandleExceptionAsync(request);
             throw;
        }
    }


    private Task HandleExceptionAsync(TRequest request)
    {

        // ResultDto<GetCustomerResponse>.Success(EnumResponses.Success, resData);

       // return ResultDto<ErrorDto>.Fail(EnumResponses.Error);
    }
    
}
