//using Mc2.CrudTest.Application.UseCases.Customer.Commands;
//using Mc2.CrudTest.Core.Commands.Customer;
//using Mc2.CrudTest.Presentation.Shared.Tools;

//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.VisualStudio.TestPlatform.TestHost;

//using System;
//using TechTalk.SpecFlow;

//namespace Mc2.CrudTest.AcceptanceTests
//{
//    [Binding]
//    public class CustmerManagerStepDefinitions
//    {
//        private CreateCustomerCommand _requestData;
//        private HttpClient _httpClient;
//        private readonly WebApplicationFactory<Program> _webApplicationFactory;

//        public CustmerManagerStepDefinitions(CreateCustomerCommand requestData)
//        {
//            _requestData = requestData;
//            TestTools.Initialize();
//            _webApplicationFactory = new WebApplicationFactory<Program>();
//            _httpClient = _webApplicationFactory.CreateDefaultClient();
//        }

//        [Given(@"Create new customer information \((.*),(.*),(.*),(.*),(.*),(.*)\)")]
//        public async Task GivenCreateNewCustomerInformation(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
//        {
//            _requestData = new CreateCustomerCommand
//            {
//                Firstname = firstName,
//                Lastname = lastName,
//                PhoneNumber = phoneNumber,
//                Email = email,
//                BankAccountNumber = bankAccountNumber,
//                DateOfBirth = dateOfBirth
//            };
//        }

//        [Then(@"Response should be succeeded")]
//        public async Task ThenResponseShouldBeSucceeded()
//        {
//            var response = await _httpClient.PostAsync("/api/customer");
//        }
//    }
//}
