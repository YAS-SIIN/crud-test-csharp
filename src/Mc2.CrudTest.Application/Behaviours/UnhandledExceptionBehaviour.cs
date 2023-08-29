using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using System.Text.Json;
using MediatR; 
using Mc2.CrudTest.Domain.DTOs;
using System.Net.Http;
using System;

namespace Mc2.CrudTest.Application.Behaviours;

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
            throw ex;
        }
    }
     
}
