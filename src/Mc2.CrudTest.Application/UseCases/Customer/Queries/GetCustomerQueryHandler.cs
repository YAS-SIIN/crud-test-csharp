﻿

using Mc2.CrudTest.Core.Queries.Customer;
using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;
using Mc2.CrudTest.Presentation.Shared.Mapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Application.UseCases.Customers.Queries;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, ResultDto<GetCustomerResponse>>
{

    private readonly IUnitOfWork _uw;
    public GetCustomerQueryHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<ResultDto<GetCustomerResponse>> Handle(GetCustomerQuery request,
        CancellationToken cancellationToken)
    {

        var response = await _uw.GetRepository<Domain.Entities.Customer>().GetByIdAsync(request.Id, cancellationToken); 

        if (response is not Domain.Entities.Customer)
            throw new ErrorException(EnumResponses.NotFound, EnumResponses.NotFound.ToString());
         
        GetCustomerResponse resData = Mapper<GetCustomerResponse, Domain.Entities.Customer>.MappClasses(response);

        return ResultDto<GetCustomerResponse>.ReturnData(EnumResponses.Success, resData);
    }
 
}