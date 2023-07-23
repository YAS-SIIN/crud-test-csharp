
using FluentValidation;

using Mc2.CrudTest.Application.Application.UseCases.Customers.Queries;
using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Core.Queries.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Presentation.Shared.Tools;

namespace Mc2.CrudTest.UnitTest.Handlers.Customer.Query;

public class GetCustomerQuery_Test
{
    private readonly GetCustomerQueryHandler _getCustomerQueryHandler;
    public GetCustomerQuery_Test()
    {

        TestTools.Initialize();
        _getCustomerQueryHandler = new GetCustomerQueryHandler(TestTools.mockUnitOfWork.Object);

    }

    [Theory]
    [InlineData(1)]
    public async Task GetCustomer_ShouldBeSucceeded(int id)
    { 
        var requestData = new GetCustomerQuery { Id = id };
        var responseData = await _getCustomerQueryHandler.Handle(requestData, CancellationToken.None);

        Assert.NotNull(responseData.Data);
    }

    [Theory]
    [InlineData(5)]
    public async Task GetCustomer_ShouldBeFailed(int id)
    {

        var requestData = new GetCustomerQuery { Id = id };

        await Assert.ThrowsAsync<ErrorException>(() => _getCustomerQueryHandler.Handle(requestData, CancellationToken.None));
    }

}
