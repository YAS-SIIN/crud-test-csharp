
using FluentValidation;

using Mc2.CrudTest.Application.Application.UseCases.Customers.Queries;
using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Queries.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Presentation.Shared.Tools;

namespace Mc2.CrudTest.UnitTest.Handlers.Customer.Query;

public class GetAllCustomerQuery_Test
{
    private readonly GetAllCustomerQueryHandler _getAllCustomerQueryHandler;
    public GetAllCustomerQuery_Test()
    {

        TestTools.Initialize();
        _getAllCustomerQueryHandler = new GetAllCustomerQueryHandler(TestTools.mockUnitOfWork.Object);

    }

    [Fact]
    public async Task GetAllCustomer_ShouldBeSucceeded()
    { 
        var requestData = new GetAllCustomerQuery();
        var responseData = await _getAllCustomerQueryHandler.Handle(requestData, CancellationToken.None);

        Assert.NotNull(responseData.Data);
        Assert.NotEqual(0, responseData.Data.Count);
    }
     
}
