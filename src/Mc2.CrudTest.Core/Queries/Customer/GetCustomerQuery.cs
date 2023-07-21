using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;

using MediatR;

namespace Mc2.CrudTest.Core.Queries.Customer;

public class GetCustomerQuery : IRequest<ResultDto<GetCustomerResponse>>
{
    /// <summary>
    /// Customer Id
    /// </summary> 
    public int Id { get; set; }
}
