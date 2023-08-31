using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Presentation;
using Microsoft.AspNetCore.Mvc.Testing;

using NUnit.Framework;

using PhoneNumbers;
using System;
using System.Net;

using System.Text;
using System.Text.Json;

using TechTalk.SpecFlow;

namespace Mc2.CrudTest.AcceptanceTests2
{
    [Binding]
    public class DeleteCustomerStepDefinitions
    {
        private DeleteCustomerCommand _requestData;
        private HttpClient _httpClient;
        private string apiUri = "/api/customer";

        public DeleteCustomerStepDefinitions(DeleteCustomerCommand requestData)
        {
            _requestData = requestData;
            var webApplicationFactory = new WebApplicationFactory<Program>();
            _httpClient = webApplicationFactory.CreateDefaultClient();
        }
        [Given(@"Delete customer information \((\d+)\)")]
        public void GivenDeleteCustomerInformation(int Id)
        {
            _requestData = new DeleteCustomerCommand
            {
                Id = Id
            };
        }

        [Then(@"Delete result should be succeeded")]
        public async Task ThenDeleteResultShouldBeSucceeded()
        {  
            var response = await _httpClient.DeleteAsync($"/api/customer/{_requestData.Id}", CancellationToken.None);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.True(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Assert.IsNotNull(result);
            var responseData = JsonSerializer.Deserialize<ResultDto<object>>(result);
            Assert.IsNotNull(responseData);
        }

        [Then(@"Delete result should be failed")]
        public async Task ThenDeleteResultShouldBeFailed()
        { 
            var response = await _httpClient.DeleteAsync($"/api/customer/{_requestData.Id}", CancellationToken.None);
            Assert.AreNotEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.False(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<ResultDto<object>>(result);
            Assert.IsNotNull(responseData);
            Assert.AreNotEqual(EnumResponseResultCodes.Success, responseData.ResultCode);
        }
    }
}
