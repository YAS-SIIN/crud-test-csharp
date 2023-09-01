using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;
using Mc2.CrudTest.Presentation.Shared.Mapper;
using MediatR;
using Mc2.CrudTest.Core.Commands.Customer;
using System.Runtime.InteropServices;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Presentation.Shared.Tools;

namespace Mc2.CrudTest.Application.UseCases.Customer.Commands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ResultDto<GetCustomerResponse>>
{
    private readonly IUnitOfWork _uw;
    public CreateCustomerCommandHandler(IUnitOfWork uw)
    {
        _uw = uw;
    }

    public async Task<ResultDto<GetCustomerResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ErrorException((int)EnumResponseStatus.BadRequest, (int)EnumResponseResultCodes.NotFound, "The input data is empty.");

        var emailExist = await _uw.GetRepository<Domain.Entities.Customer>().ExistDataAsync(cancellationToken, x => x.Email.Equals(request.Email));

        if (emailExist)
            throw new ErrorException((int)EnumResponseStatus.BadRequest, (int)EnumResponseResultCodes.RepeatedData, "Email is repeated.");
         
        //Domain.Entities.Customer inputData = Mapper<Domain.Entities.Customer, CreateCustomerCommand>.MappClasses(request);
        Domain.Entities.Customer inputData = new Domain.Entities.Customer(request?.Firstname, request?.Lastname, request.DateOfBirth.Value, request?.PhoneNumber, request?.Email, request?.BankAccountNumber);

        await _uw.GetRepository<Domain.Entities.Customer>().AddAsync(inputData, cancellationToken, true);

        GetCustomerResponse outputData = Mapper<GetCustomerResponse, Domain.Entities.Customer>.MappClasses(inputData);

        return ResultDto<GetCustomerResponse>.ReturnData(outputData, (int)EnumResponseStatus.OK, (int)EnumResponseResultCodes.Success, EnumResponseResultCodes.Success.GetDisplayName());
    }
}
