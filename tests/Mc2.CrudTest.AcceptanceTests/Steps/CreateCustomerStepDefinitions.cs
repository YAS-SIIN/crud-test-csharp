using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Presentation.Shared.Tools;

using Microsoft.VisualStudio.TestPlatform.Common;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

using NUnit.Framework;

using System;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests.Steps;

[Binding]
public class CreateCustomerStepDefinitions
{
    private CreateCustomerCommand _requestData;
    private readonly CreateCustomerCommandHandler _createCustomerCommandHandler;

    public CreateCustomerStepDefinitions(CreateCustomerCommand requestData)
    {
        _requestData = requestData;
        TestTools.Initialize();
        _createCustomerCommandHandler = new CreateCustomerCommandHandler(TestTools.mockUnitOfWork.Object);
    }

    [Given(@"customer information \((.*),(.*),(.*),(.*),(.*),(.*)\)")]
    public void GivenCustomerInformation(string firstName, string lastName, DateTime dateOfBirth,
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

    [When(@"validation is true")]
    public async Task WhenValidationIsTrue()
    {
        var validation = await new CreateCustomerCommandValidator().ValidateAsync(_requestData);
        Assert.True(validation.IsValid);

    }

    [Then(@"result should be succeeded")]
    public async Task ThenResultShouldBeSucceeded()
    {
        var responseData = await _createCustomerCommandHandler.Handle(_requestData, CancellationToken.None);

        Assert.AreEqual(EnumResponses.Success, responseData.StatusCode);
    }
}
