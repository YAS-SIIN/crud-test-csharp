
using Mc2.CrudTest.Domain.DTOs.Exceptions;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private IMediator _mediator;      
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    public IActionResult OkData<TData>(ResultDto<TData> response)
    {
        return new ObjectResult(response);
    }
}
