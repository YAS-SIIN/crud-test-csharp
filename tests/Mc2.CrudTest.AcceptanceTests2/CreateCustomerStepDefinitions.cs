
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Presentation;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests2;


[Binding]
public class CreateCustomerStepDefinitions
{
    private CreateCustomerCommand _requestData; 
    private HttpClient _httpClient; 
    private string apiUri = "/api/customer"; 
     
    public CreateCustomerStepDefinitions(CreateCustomerCommand requestData)
    {
        _requestData = requestData;
        var webApplicationFactory = new WebApplicationFactory<Program>();
        _httpClient = webApplicationFactory.CreateDefaultClient();
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
     
    [Then(@"Create result should be succeeded")]
    public async Task ThenCreateResultShouldBeSucceeded()
    {
        var payload = JsonSerializer.Serialize(_requestData);

        HttpContent httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
        var response =await _httpClient.PostAsync("/api/customer", httpContent, CancellationToken.None);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.True(response.IsSuccessStatusCode);
        var result = await response.Content.ReadAsStringAsync();
        Assert.IsNotNull(result);
        var responseData = JsonSerializer.Deserialize<ResultDto<object>>(result);
        Assert.IsNotNull(responseData);
    }

    [Then(@"Create result should be failed")]
    public async Task ThenCreateResultShouldBeFailed()
    {
        var payload = JsonSerializer.Serialize(_requestData);

        HttpContent httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("/api/customer", httpContent, CancellationToken.None);
        Assert.AreNotEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.False(response.IsSuccessStatusCode);
        var result = await response.Content.ReadAsStringAsync();
        var responseData = JsonSerializer.Deserialize<ResultDto<object>>(result);
        Assert.IsNotNull(responseData);
        Assert.AreNotEqual(EnumResponseResultCodes.Success, responseData.ResultCode);

    }

}

