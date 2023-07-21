

using Mc2.CrudTest.Core.Queries.Customer;
using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;
using Mc2.CrudTest.Presentation.Shared.Mapper;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Application.Application.UseCases.Customers.Queries;

public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, ResultDto<IList<GetAllCustomerResponse>>>
{

    private readonly IUnitOfWork _uw;
    public GetAllCustomerQueryHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<ResultDto<IList<GetAllCustomerResponse>>> Handle(GetAllCustomerQuery request,
        CancellationToken cancellationToken)
    {

        var response = await _uw.GetRepository<Domain.Entities.Customer>().GetAllAsync(cancellationToken); 
        var resData = Mapper<IList<GetAllCustomerResponse>, IList<Domain.Entities.Customer>>.MappClasses(response.ToList());
        return ResultDto<IList<GetAllCustomerResponse>>.Success(EnumResponses.Success, resData);
    }
 
}