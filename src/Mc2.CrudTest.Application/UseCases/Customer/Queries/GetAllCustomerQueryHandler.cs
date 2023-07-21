

using Mc2.CrudTest.Core.Queries.Customer;
using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;
using Mc2.CrudTest.Presentation.Shared.Mapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Application.UseCases.Customers.Queries;

public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, ResultDto<IList<GetCustomerResponse>>>
{

    private readonly IUnitOfWork _uw;
    public GetAllCustomerQueryHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<ResultDto<IList<GetCustomerResponse>>> Handle(GetAllCustomerQuery request,
        CancellationToken cancellationToken)
    {

        var response = await _uw.GetRepository<Domain.Entities.Customer>().GetAllAsync(cancellationToken); 
        var resData = response.Select(x=> new GetCustomerResponse {
            Firstname = x.Firstname, Lastname = x.Lastname, 
            DateOfBirth = x.DateOfBirth, PhoneNumber = x.PhoneNumber, Email = x.Email, BankAccountNumber = x.BankAccountNumber, Id = x.Id
            }).ToList();
        return ResultDto<IList<GetCustomerResponse>>.ReturnData(EnumResponses.Success, resData);
    }
 
}