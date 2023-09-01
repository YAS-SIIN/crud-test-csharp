
using Mc2.CrudTest.Domain.Enums;

using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Presentation.Shared.Tools;

using PhoneNumbers;

namespace Mc2.CrudTest.UnitTest.Handlers.Customer.Command;

public class CreateCustomerCommand_Test
{
    private readonly CreateCustomerCommandHandler _createCustomerCommandHandler;
    private readonly CreateCustomerCommandValidator _validationRules;
    public CreateCustomerCommand_Test()
    {
        TestTools.Initialize();
        _createCustomerCommandHandler = new CreateCustomerCommandHandler(TestTools._mockUnitOfWork.Object);
        _validationRules = new CreateCustomerCommandValidator();
    }

    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_CreateCustomer_WithEverythingIsOk), MemberType = typeof(CreateCustomerCommand_Data))] 
    public async Task CreateCustomer_WhenEverythingIsOk_ShouldBeSucceeded(CreateCustomerCommand requestData)
    { 
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(validation.IsValid);

        var responseData = await _createCustomerCommandHandler.Handle(requestData, CancellationToken.None);

        Assert.Equal((int)EnumResponseStatus.OK, responseData.StatusCode);
        TestTools._mockUnitOfWork.Object.Dispose();
    }

    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_CreateCustomer_WithFirstnameIsEmpty_ShouldBeFailed), MemberType = typeof(CreateCustomerCommand_Data))]
    public async Task CreateCustomer_WhenFirstnameIsEmpty_ShouldBeFailed(CreateCustomerCommand requestData)
    {  
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.False(validation.IsValid);
 
    }

    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_Check_PhoneNumberIsMobile_ShouldBeSuccess), MemberType = typeof(CreateCustomerCommand_Data))]
    public async Task Check_PhoneNumberIsMobile_ShouldBeSuccess(CreateCustomerCommand requestData)
    {

        var phoneNumber = PhoneNumberUtil.GetInstance().Parse(requestData.PhoneNumber, "");
        PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
        var type = phoneNumberUtil.GetNumberType(phoneNumber);
        Assert.Equal(PhoneNumbers.PhoneNumberType.MOBILE, type); 
         
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(validation.IsValid);
        
    }
    
    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_Check_PhoneNumberIsMobile_ShouldBeFaild), MemberType = typeof(CreateCustomerCommand_Data))]
    public async Task Check_PhoneNumberIsMobile_ShouldBeFaild(CreateCustomerCommand requestData)
    {
        var phoneNumber = PhoneNumberUtil.GetInstance().Parse(requestData.PhoneNumber, "");
        PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
        var type = phoneNumberUtil.GetNumberType(phoneNumber); 
        Assert.NotEqual(PhoneNumbers.PhoneNumberType.MOBILE, type);

        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.False(validation.IsValid);
 
    }
    
    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_CreateCustomer_WithLastnameIsEmpty_ShouldBeFailed), MemberType = typeof(CreateCustomerCommand_Data))]
    public async Task CreateCustomer_WhenLastnameIsEmpty_ShouldBeFailed(CreateCustomerCommand requestData)
    {
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.False(validation.IsValid);
 
    }
    
    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_CreateCustomer_WithBankAccountNumberIsNotValid), MemberType = typeof(CreateCustomerCommand_Data))]
    public async Task CreateCustomer_WhenBankAccountNumberIsNotValid_ShouldBeFailed(CreateCustomerCommand requestData)
    {  
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.False(validation.IsValid);
 
    }

    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_CreateCustomer_WithEmailIsNotValid), MemberType = typeof(CreateCustomerCommand_Data))]
    public async Task CreateCustomer_WhenEmailIsNotValid_ShouldBeFailed(CreateCustomerCommand requestData)
    {   
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.False(validation.IsValid);
    }

    [Theory]
    [MemberData(nameof(CreateCustomerCommand_Data.SetDataFor_CreateCustomer_WithEmailExistsBefore), MemberType = typeof(CreateCustomerCommand_Data))]
    public async Task CreateCustomer_WhenEmailExistsBefore_ShouldBeFailed(CreateCustomerCommand requestData)
    {  
        var validation = await _validationRules.ValidateAsync(requestData);
        Assert.True(validation.IsValid);

        await Assert.ThrowsAsync<ErrorException>(async() => await _createCustomerCommandHandler.Handle(requestData, CancellationToken.None));
        TestTools._mockUnitOfWork.Object.Dispose();

    }
}
