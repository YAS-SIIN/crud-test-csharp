using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Presentation.Shared.Tools;
using System;
using System.Net.Http;

using System.Net;

using System.Text;

using TechTalk.SpecFlow;
using Microsoft.AspNetCore.Mvc.Testing;
using Mc2.CrudTest.Presentation;
using System.Text.Json;
using NUnit.Framework;
using Mc2.CrudTest.Domain.Enums;

namespace Mc2.CrudTest.AcceptanceTests2
{
    [Binding]
    public class UpdateCustomerStepDefinitions
    {
        private UpdateCustomerCommand _requestData;
        private HttpClient _httpClient;
        private string apiUri = "/api/customer";

        public UpdateCustomerStepDefinitions(UpdateCustomerCommand requestData)
        {
            _requestData = requestData;
            var webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.CreateDefaultClient();
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

        [Then(@"Update result should be succeeded")]
        public async Task ThenUpdateResultShouldBeSucceeded()
        {
            var payload = JsonSerializer.Serialize(_requestData);

            HttpContent httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("/api/customer", httpContent, CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Assert.IsNotNull(result);
            var responseData = JsonSerializer.Deserialize<ResultDto<object>>(result);
            Assert.IsNotNull(responseData);
        }

        [Then(@"Update result should be failed")]
        public async Task ThenUpdateResultShouldBeFailed()
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
}
