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
public class UpdateCustomerStepDefinitions
{
    private UpdateCustomerCommand _requestData;
    private readonly UpdateCustomerCommandHandler _UpdateCustomerCommandHandler;

    public UpdateCustomerStepDefinitions(UpdateCustomerCommand requestData)
    {
        _requestData = requestData;
        TestTools.Initialize();
        _UpdateCustomerCommandHandler = new UpdateCustomerCommandHandler(TestTools._mockUnitOfWork.Object);
    }
    [Given(@"Update customer information \((\d+),(.*),(.*),(.*),(.*),(.*),(.*)\)")]
    public void GivenUpdateCustomerInformation(int id, string firstName, string lastName, DateTime dateOfBirth,
    string phoneNumber, string email, string bankAccountNumber)
    {
        _requestData = new UpdateCustomerCommand
        {
            Id = id,
            Firstname = firstName,
            Lastname = lastName,
            PhoneNumber = phoneNumber,
            Email = email,
            BankAccountNumber = bankAccountNumber,
            DateOfBirth = dateOfBirth
        };
    }

    [When(@"Update validation is true")]
    public async Task WhenUpdateValidationIsTrue()
    {
        var validation = await new UpdateCustomerCommandValidator().ValidateAsync(_requestData);
        Assert.True(validation.IsValid);
    }
    [Then(@"Update validation should be false")]
    public async Task ThenUpdateValidationShouldBeFalse()
    {
        var validation = await new UpdateCustomerCommandValidator().ValidateAsync(_requestData);
        Assert.False(validation.IsValid);
    }

    [Then(@"Update result should be succeeded")]
    public async Task ThenUpdateResultShouldBeSucceeded()
    {
        var responseData = await _UpdateCustomerCommandHandler.Handle(_requestData, CancellationToken.None);

        Assert.AreEqual(EnumResponseStatus.OK, responseData.StatusCode);
    }

    [Then(@"Update result should be failed")]
    public void ThenUpdateResultShouldBeFailed()
    {
        Assert.ThrowsAsync<ErrorException>(() => _UpdateCustomerCommandHandler.Handle(_requestData, CancellationToken.None));
    }
}
