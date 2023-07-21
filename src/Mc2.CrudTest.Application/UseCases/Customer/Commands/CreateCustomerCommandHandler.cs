﻿using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;

using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;
using Mc2.CrudTest.Presentation.Shared.Mapper;

using MediatR;
using Mc2.CrudTest.Core.Commands.Customer;

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
        Domain.Entities.Customer inputData = Mapper<Domain.Entities.Customer, CreateCustomerCommand>.MappClasses(request);
        await _uw.GetRepository<Domain.Entities.Customer>().AddAsync(inputData, cancellationToken, true);

        GetCustomerResponse outputData = Mapper<GetCustomerResponse, Domain.Entities.Customer>.MappClasses(inputData);

        return ResultDto<GetCustomerResponse>.ReturnData(EnumResponses.Success, outputData);
    }
}
