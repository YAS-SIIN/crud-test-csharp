
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
    private readonly UpdateCustomerCommandValidator _validationRules;
    public UpdateCustomerCommand_Test()
    {
        TestTools.Initialize();
        _updateCustomerCommandHandler = new UpdateCustomerCommandHandler(TestTools._mockUnitOfWork.Object);
        _validationRules = new UpdateCustomerCommandValidator();

    }

    [Theory]
    [MemberData(nameof(UpdateCustomerCommand_Data.SetDataFor_UpdateCustomer_WithEverythingIsOk), MemberType = typeof(UpdateCustomerCommand_Data))] 
    public async Task UpdateCustomer_WhenEverythingIsOk_ShouldBeSucceeded(UpdateCustomerCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(validation.IsValid);

        var responseUpdateData = await _updateCustomerCommandHandler.Handle(requestData, CancellationToken.None);

        Assert.Equal((int)EnumResponseStatus.OK, responseUpdateData.StatusCode);
        TestTools._mockUnitOfWork.Object.Dispose();
    }

    [Theory]
    [MemberData(nameof(UpdateCustomerCommand_Data.SetDataFor_UpdateCustomer_WithFirstnameIsEmpty_ShouldBeFailed), MemberType = typeof(UpdateCustomerCommand_Data))]
    public async Task UpdateCustomer_WhenFirstnameIsEmpty_ShouldBeFailed(UpdateCustomerCommand requestData)
    {  
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.False(validation.IsValid);
 
    }
    
    [Theory]
    [MemberData(nameof(UpdateCustomerCommand_Data.SetDataFor_UpdateCustomer_WithLastnameIsEmpty_ShouldBeFailed), MemberType = typeof(UpdateCustomerCommand_Data))]
    public async Task UpdateCustomer_WhenLastnameIsEmpty_ShouldBeFailed(UpdateCustomerCommand requestData)
    {  
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.False(validation.IsValid);
 
    }
    
    [Theory]
    [MemberData(nameof(UpdateCustomerCommand_Data.SetDataFor_UpdateCustomer_WithBankAccountNumberIsNotValid), MemberType = typeof(UpdateCustomerCommand_Data))]
    public async Task UpdateCustomer_WhenBankAccountNumberIsNotValid_ShouldBeFailed(UpdateCustomerCommand requestData)
    {  
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.False(validation.IsValid);
 
    }

    [Theory]
    [MemberData(nameof(UpdateCustomerCommand_Data.SetDataFor_UpdateCustomer_WithEmailIsNotValid), MemberType = typeof(UpdateCustomerCommand_Data))]
    public async Task UpdateCustomer_WhenEmailIsNotValid_ShouldBeFailed(UpdateCustomerCommand requestData)
    {   
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.False(validation.IsValid);
    }

    [Theory]
    [MemberData(nameof(UpdateCustomerCommand_Data.SetDataFor_UpdateCustomer_WithEmailExistsBefore), MemberType = typeof(UpdateCustomerCommand_Data))]
    public async Task UpdateCustomer_WhenEmailExistsBefore_ShouldBeFailed(UpdateCustomerCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(validation.IsValid);

       await Assert.ThrowsAsync<ErrorException>(async () => await _updateCustomerCommandHandler.Handle(requestData, CancellationToken.None));
        TestTools._mockUnitOfWork.Object.Dispose();

    }
}
