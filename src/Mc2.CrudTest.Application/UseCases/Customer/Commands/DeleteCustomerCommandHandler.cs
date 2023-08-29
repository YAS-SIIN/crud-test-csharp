using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;
using Mc2.CrudTest.Presentation.Shared.Mapper;
using MediatR;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Presentation.Shared.Tools;

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
            throw new ErrorException((int)EnumResponseStatus.NotFound, (int)EnumResponseResultCodes.NotFound, EnumResponseResultCodes.NotFound.ToString()); 

        _uw.GetRepository<Domain.Entities.Customer>().Delete(inputData, true);
         
        return ResultDto<int>.ReturnData(request.Id, (int)EnumResponseStatus.OK, (int)EnumResponseResultCodes.Success, EnumResponseResultCodes.Success.GetDisplayName());
    }
}
