
using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;
 
namespace Mc2.CrudTest.UnitTest.Handlers.Customer.Command;

public class CreateCustomerCommand_Test
{
    private readonly CreateCustomerCommandHandler _createCustomerCommandHandler;
    public CreateCustomerCommand_Test()
    {

        TestTools.Initialize();
        _createCustomerCommandHandler = new CreateCustomerCommandHandler(TestTools.mockUnitOfWork.Object);

    }

    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_CreateCustomer_WithEverythingIsOk), MemberType = typeof(CreateCustomerCommand_Data))] 
    public async Task CreateCustomer_WhenEverythingIsOk_ShouldBeSucceeded(CreateCustomerCommand requestData)
    { 
        var validation = await new CreateCustomerCommandValidator().ValidateAsync(requestData);
        Assert.True(validation.IsValid);

        var responseData = await _createCustomerCommandHandler.Handle(requestData, CancellationToken.None);

        Assert.Equal(EnumResponses.Success, responseData.StatusCode);
    }

    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_CreateCustomer_WithFirstnameIsEmpty_ShouldBeFailed), MemberType = typeof(CreateCustomerCommand_Data))]
    public async Task CreateCustomer_WhenFirstnameIsEmpty_ShouldBeFailed(CreateCustomerCommand requestData)
    {  
        var validation = await new CreateCustomerCommandValidator().ValidateAsync(requestData);
        Assert.False(validation.IsValid);
 
    }
    
    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_CreateCustomer_WithFirstnameIsEmpty_ShouldBeFailed), MemberType = typeof(CreateCustomerCommand_Data))]
    public async Task CreateCustomer_WhenLastnameIsEmpty_ShouldBeFailed(CreateCustomerCommand requestData)
    {  
        var validation = await new CreateCustomerCommandValidator().ValidateAsync(requestData);
        Assert.False(validation.IsValid);
 
    }
    
    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_CreateCustomer_WithBankAccountNumberIsNotValid), MemberType = typeof(CreateCustomerCommand_Data))]
    public async Task CreateCustomer_WhenBankAccountNumberIsNotValid_ShouldBeFailed(CreateCustomerCommand requestData)
    {  
        var validation = await new CreateCustomerCommandValidator().ValidateAsync(requestData);
        Assert.False(validation.IsValid);
 
    }

    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_CreateCustomer_WithEmailIsNotValid), MemberType = typeof(CreateCustomerCommand_Data))]
    public async Task CreateCustomer_WhenEmailIsNotValid_ShouldBeFailed(CreateCustomerCommand requestData)
    {   
        var validation = await new CreateCustomerCommandValidator().ValidateAsync(requestData);
        Assert.False(validation.IsValid);
    }

    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_CreateCustomer_WithEmailExistsBefore), MemberType = typeof(CreateCustomerCommand_Data))]
    public async Task CreateCustomer_WhenEmailExistsBefore_ShouldBeFailed(CreateCustomerCommand requestData)
    {  
        var validation = await new CreateCustomerCommandValidator().ValidateAsync(requestData);
        Assert.True(validation.IsValid);
        
        Assert.ThrowsAsync<ErrorException>(() => _createCustomerCommandHandler.Handle(requestData, CancellationToken.None));
  

    }
}
