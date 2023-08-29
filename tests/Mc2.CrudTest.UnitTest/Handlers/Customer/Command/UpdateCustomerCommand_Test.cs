
using FluentValidation;

using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Presentation.Shared.Tools;

namespace Mc2.CrudTest.UnitTest.Handlers.Customer.Command;

public class UpdateCustomerCommand_Test
{
    private readonly UpdateCustomerCommandHandler _updateCustomerCommandHandler;
    public UpdateCustomerCommand_Test()
    {

        TestTools.Initialize();
        _updateCustomerCommandHandler = new UpdateCustomerCommandHandler(TestTools.mockUnitOfWork.Object);

    }

    [Theory]
    [MemberData(nameof(UpdateCustomerCommand_Data.SetDataFor_UpdateCustomer_WithEverythingIsOk), MemberType = typeof(UpdateCustomerCommand_Data))] 
    public async Task UpdateCustomer_WhenEverythingIsOk_ShouldBeSucceeded(UpdateCustomerCommand requestData)
    {
        var validation = await new UpdateCustomerCommandValidator().ValidateAsync(requestData);
        Assert.True(validation.IsValid);

        var responseUpdateData = await _updateCustomerCommandHandler.Handle(requestData, CancellationToken.None);

        Assert.Equal((int)EnumResponseStatus.OK, responseUpdateData.StatusCode);
    }

    [Theory]
    [MemberData(nameof(UpdateCustomerCommand_Data.SetDataFor_UpdateCustomer_WithFirstnameIsEmpty_ShouldBeFailed), MemberType = typeof(UpdateCustomerCommand_Data))]
    public async Task UpdateCustomer_WhenFirstnameIsEmpty_ShouldBeFailed(UpdateCustomerCommand requestData)
    {  
        var validation = await new UpdateCustomerCommandValidator().ValidateAsync(requestData);
        Assert.False(validation.IsValid);
 
    }
    
    [Theory]
    [MemberData(nameof(UpdateCustomerCommand_Data.SetDataFor_UpdateCustomer_WithLastnameIsEmpty_ShouldBeFailed), MemberType = typeof(UpdateCustomerCommand_Data))]
    public async Task UpdateCustomer_WhenLastnameIsEmpty_ShouldBeFailed(UpdateCustomerCommand requestData)
    {  
        var validation = await new UpdateCustomerCommandValidator().ValidateAsync(requestData);
        Assert.False(validation.IsValid);
 
    }
    
    [Theory]
    [MemberData(nameof(UpdateCustomerCommand_Data.SetDataFor_UpdateCustomer_WithBankAccountNumberIsNotValid), MemberType = typeof(UpdateCustomerCommand_Data))]
    public async Task UpdateCustomer_WhenBankAccountNumberIsNotValid_ShouldBeFailed(UpdateCustomerCommand requestData)
    {  
        var validation = await new UpdateCustomerCommandValidator().ValidateAsync(requestData);
        Assert.False(validation.IsValid);
 
    }

    [Theory]
    [MemberData(nameof(UpdateCustomerCommand_Data.SetDataFor_UpdateCustomer_WithEmailIsNotValid), MemberType = typeof(UpdateCustomerCommand_Data))]
    public async Task UpdateCustomer_WhenEmailIsNotValid_ShouldBeFailed(UpdateCustomerCommand requestData)
    {   
        var validation = await new UpdateCustomerCommandValidator().ValidateAsync(requestData);
        Assert.False(validation.IsValid);
    }

    [Theory]
    [MemberData(nameof(UpdateCustomerCommand_Data.SetDataFor_UpdateCustomer_WithEmailExistsBefore), MemberType = typeof(UpdateCustomerCommand_Data))]
    public async Task UpdateCustomer_WhenEmailExistsBefore_ShouldBeFailed(UpdateCustomerCommand requestData)
    {
        var validation = await new UpdateCustomerCommandValidator().ValidateAsync(requestData);
        Assert.True(validation.IsValid);

       await Assert.ThrowsAsync<ErrorException>(() => _updateCustomerCommandHandler.Handle(requestData, CancellationToken.None));


    }
}
