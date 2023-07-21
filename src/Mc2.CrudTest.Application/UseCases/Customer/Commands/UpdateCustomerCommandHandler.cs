using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;

using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;
using Mc2.CrudTest.Presentation.Shared.Mapper;

using MediatR;
using Mc2.CrudTest.Core.Commands.Customer;

namespace Mc2.CrudTest.Application.UseCases.Customer.Commands;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ResultDto<GetCustomerResponse>>
{
    private readonly IUnitOfWork _uw;
    public UpdateCustomerCommandHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<ResultDto<GetCustomerResponse>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Customer inputData = Mapper<Domain.Entities.Customer, UpdateCustomerCommand>.MappClasses(request);
        _uw.GetRepository<Domain.Entities.Customer>().Update(inputData, true);

        GetCustomerResponse outputData = Mapper<GetCustomerResponse, Domain.Entities.Customer>.MappClasses(inputData);

        return ResultDto<GetCustomerResponse>.ReturnData(EnumResponses.Success, outputData);
    }
}
