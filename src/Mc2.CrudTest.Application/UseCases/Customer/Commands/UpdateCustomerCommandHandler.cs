using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;
using Mc2.CrudTest.Presentation.Shared.Mapper;
using MediatR;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Presentation.Shared.Tools;

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
        var inputData = await _uw.GetRepository<Domain.Entities.Customer>().GetByIdAsync((object)request.Id, cancellationToken);

        if (inputData is null && inputData is not Domain.Entities.Customer)
            throw new ErrorException((int)EnumResponseStatus.NotFound, (int)EnumResponseResultCodes.NotFound, EnumResponseResultCodes.NotFound.ToString()); 

        var emailExist = await _uw.GetRepository<Domain.Entities.Customer>().ExistDataAsync(cancellationToken, x => x.Email.Equals(request.Email) && x.Id != request.Id);

        if (emailExist)
            throw new ErrorException((int)EnumResponseStatus.BadRequest, (int)EnumResponseResultCodes.RepeatedData, "Email is repeated.");
         
        //inputData = Mapper<Domain.Entities.Customer, UpdateCustomerCommand>.MappClasses(request);
        inputData.Firstname = request.Firstname;
        inputData.Lastname = request.Lastname;
        inputData.DateOfBirth = request.DateOfBirth.Value;
        inputData.PhoneNumber = request.PhoneNumber;
        inputData.Email = request.Email;
        inputData.BankAccountNumber = request.BankAccountNumber;
       
        _uw.GetRepository<Domain.Entities.Customer>().Update(inputData, true);

        GetCustomerResponse outputData = Mapper<GetCustomerResponse, Domain.Entities.Customer>.MappClasses(inputData);

        return ResultDto<GetCustomerResponse>.ReturnData(outputData, (int)EnumResponseStatus.OK, (int)EnumResponseResultCodes.Success, EnumResponseResultCodes.Success.GetDisplayName());
    }
}
