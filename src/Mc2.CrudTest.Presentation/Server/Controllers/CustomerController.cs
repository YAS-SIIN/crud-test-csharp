﻿

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
    /// Get all customer.
    /// </summary>
    /// <returns>Result</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllCustomerQuery();
        return OkData(await Mediator.Send(query));
    }

    /// <summary>
    /// Get customer.
    /// </summary>
    /// <returns>Result</returns>
    [HttpGet("{Id}")]
    public async Task<IActionResult> Get([FromRoute] GetCustomerQuery query, CancellationToken cancellation)
    { 
        return OkData(await Mediator.Send(query, cancellation));
    }

    /// <summary>
    /// Creates a new customer.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Result</returns>
    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommand command, CancellationToken cancellation)
    {
        return OkData(await Mediator.Send(command, cancellation));
    }

    /// <summary>
    /// Update customer.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Result</returns>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateCustomerCommand command, CancellationToken cancellation)
    {
        return OkData(await Mediator.Send(command, cancellation));
    }

    /// <summary>
    /// Delete customer.
    /// </summary>
    /// <returns>Result</returns>
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete([FromRoute] DeleteCustomerCommand command, CancellationToken cancellation)
    { 

        return OkData(await Mediator.Send(command, cancellation));
    }

}
