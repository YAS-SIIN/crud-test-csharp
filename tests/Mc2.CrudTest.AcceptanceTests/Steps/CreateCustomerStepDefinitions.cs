using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Presentation.Shared.Tools;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests.Steps;

[Binding]
public class CreateCustomerStepDefinitions
{
    private CreateCustomerCommand _requestData;
    private readonly CreateCustomerCommandHandler _createCustomerCommandHandler;
    private readonly CreateCustomerCommandValidator _validationRules;

    public CreateCustomerStepDefinitions(CreateCustomerCommand requestData)
    {
        _requestData = requestData;
        TestTools.Initialize();
        _createCustomerCommandHandler = new CreateCustomerCommandHandler(TestTools._mockUnitOfWork.Object);
        _validationRules = new CreateCustomerCommandValidator();
    }
    [Given(@"Create customer information \((.*),(.*),(.*),(.*),(.*),(.*)\)")]
    public void GivenCreateCustomerInformation(string firstName, string lastName, DateTime dateOfBirth,
    string phoneNumber, string email, string bankAccountNumber)
    {
        _requestData = new CreateCustomerCommand
        {
            Firstname = firstName,
            Lastname = lastName,
            PhoneNumber = phoneNumber,
            Email = email,
            BankAccountNumber = bankAccountNumber,
            DateOfBirth = dateOfBirth
        };
    }

    [When(@"Create validation is true")]
    public async Task WhenCreateValidationIsTrue()
    {
        var validation = await _validationRules.ValidateAsync(_requestData);
        Assert.True(validation.IsValid);
    }
    [Then(@"Create validation should be false")]
    public async Task ThenCreateValidationShouldBeFalse()
    {
        var validation = await _validationRules.ValidateAsync(_requestData);
        Assert.False(validation.IsValid);
    }

    [Then(@"Create result should be succeeded")]
    public async Task ThenCreateResultShouldBeSucceeded()
    {
        var responseData = await _createCustomerCommandHandler.Handle(_requestData, CancellationToken.None);

        Assert.AreEqual((int)EnumResponseStatus.OK, responseData.StatusCode);
    }

    [Then(@"Create result should be failed")]
    public void ThenCreateResultShouldBeFailed()
    { 
        Assert.ThrowsAsync<ErrorException>(() => _createCustomerCommandHandler.Handle(_requestData, CancellationToken.None));
    }

}
