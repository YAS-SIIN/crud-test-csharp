
using FluentValidation;

using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.DTOs.Exceptions;
using Mc2.CrudTest.Domain.Enums;
using Mc2.CrudTest.Presentation.Shared.Tools;

namespace Mc2.CrudTest.UnitTest.Handlers.Customer.Command;

public class DeleteCustomerCommand_Test
{
    private readonly DeleteCustomerCommandHandler _deleteCustomerCommandHandler;
    public DeleteCustomerCommand_Test()
    {

        TestTools.Initialize();
        _deleteCustomerCommandHandler = new DeleteCustomerCommandHandler(TestTools._mockUnitOfWork.Object);

    }

    [Theory]
    [InlineData(3)]
    public async Task DeleteCustomer_WhenEverythingIsOk_ShouldBeSucceeded(int id)
    { 
        var requestData = new DeleteCustomerCommand { Id = id };
        var responseData = await _deleteCustomerCommandHandler.Handle(requestData, CancellationToken.None);

        Assert.Equal((int)EnumResponseStatus.OK, responseData.StatusCode);
        TestTools._mockUnitOfWork.Object.Dispose();
    }

    [Theory]
    [InlineData(999)]
    public async Task DeleteCustomer_WhenIdNotFound_ShouldBeFailed(int id)
    {

        var requestData = new DeleteCustomerCommand { Id = id };

        await Assert.ThrowsAsync<ErrorException>(async () => await _deleteCustomerCommandHandler.Handle(requestData, CancellationToken.None));
        TestTools._mockUnitOfWork.Object.Dispose();
    }
}
