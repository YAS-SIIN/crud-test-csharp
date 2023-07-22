
using FluentValidation;

using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;
 
namespace Mc2.CrudTest.UnitTest.Handlers.Customer.Command;

public class DeleteCustomerCommand_Test
{
    private readonly DeleteCustomerCommandHandler _deleteCustomerCommandHandler;
    public DeleteCustomerCommand_Test()
    {

        TestTools.Initialize();
        _deleteCustomerCommandHandler = new DeleteCustomerCommandHandler(TestTools.mockUnitOfWork.Object);

    }

    [Theory]
    [InlineData(1)]
    public async Task DeleteCustomer_WhenEverythingIsOk_ShouldBeSucceeded(int id)
    { 
        var requestData = new DeleteCustomerCommand { Id = id };
        var responseData = await _deleteCustomerCommandHandler.Handle(requestData, CancellationToken.None);

        Assert.Equal(EnumResponses.Success, responseData.StatusCode);
    }

    [Theory]
    [InlineData(5)]
    public async Task DeleteCustomer_WhenIdNotFound_ShouldBeFailed(int id)
    {

        var requestData = new DeleteCustomerCommand { Id = id };

        await Assert.ThrowsAsync<ErrorException>(() => _deleteCustomerCommandHandler.Handle(requestData, CancellationToken.None));
    }
}
