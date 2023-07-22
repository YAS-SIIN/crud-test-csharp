using Mc2.CrudTest.Application.UseCases.Customer.Commands;
using Mc2.CrudTest.Core.Commands.Customer;
using Mc2.CrudTest.Domain.Interfaces.UnitOfWork;

using Moq;



namespace Mc2.CrudTest.UnitTest.Handlers.Customer.Command
{
    public class CreateCustomer_Test
    {
        private readonly CreateCustomerCommandHandler _createCustomerCommandHandler;
        private readonly CancellationToken _cancellationToken;
        public CreateCustomer_Test()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            _createCustomerCommandHandler = new CreateCustomerCommandHandler(mockUnitOfWork.Object);
            _cancellationToken = new CancellationToken();
        }

        [Fact]
        public async Task test()
        {
            var aa = new CreateCustomerCommand() { Firstname ="test", Email = "aa@aa.com"};
            var aab = await _createCustomerCommandHandler.Handle(aa, _cancellationToken);
          
            Assert.Equal(200, aab.StatusCode);
        }
    }
}
