

using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Queries.Customer;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : BaseApiController
{

    /// <summary>
    /// Creates a New Employee.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommand command)
    {
        return OkData(await Mediator.Send(command));
    }

    /// <summary>
    /// Get All Employees.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllCustomerQuery();
        return OkData(await Mediator.Send(query));
    }

}
