
using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;

using MediatR;
 
namespace Mc2.CrudTest.Core.Queries.Customer;

public class GetAllCustomerQuery : IRequest<ResultDto<IList<GetAllCustomerResponse>>>
{
}
