using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;

using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;
using Mc2.CrudTest.Presentation.Shared.Mapper;

using MediatR;
using Mc2.CrudTest.Core.Commands.Customer;

namespace Mc2.CrudTest.Application.UseCases.Customer.Commands;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ResultDto<int>>
{
    private readonly IUnitOfWork _uw;
    public DeleteCustomerCommandHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<ResultDto<int>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var inputData = await _uw.GetRepository<Domain.Entities.Customer>().GetByIdAsync(request.Id, cancellationToken);

        if (inputData is not Domain.Entities.Customer)
            throw new ErrorException(EnumResponses.NotFound, EnumResponses.NotFound.ToString());

        _uw.GetRepository<Domain.Entities.Customer>().Delete(inputData, true);
         
        return ResultDto<int>.ReturnData(EnumResponses.Success, request.Id);
    }
}
