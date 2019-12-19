using HomeFinance.Application.Stores.Commands;

using System.Threading;
using System.Threading.Tasks;
using HomeFinance.Persistence;
using Xunit;
using HomeFinance.Application.Tests.Infrastructure;
using System.Linq;

namespace HomeFinance.Application.Tests.Stores.Commands
{
    public class AddStoreCommandTests : TestBase
    {
        private readonly HomeFinanceDbContext _context;
        private readonly AddStoreCommandHandler _commandHandler;

        public AddStoreCommandTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
            _commandHandler = new AddStoreCommandHandler(_context);
        }

        [Fact]
        public async Task AddStoreCommandTest()
        {
            // Arrange
            var command = new AddStoreCommand
            {
                StoreName = "Target",
                Active = true
            };

            // Act
            var id = await _commandHandler.Handle(command, CancellationToken.None);

            var store = await _context.Stores.FindAsync(id);

            // Assert
            Assert.Equal(command.StoreName, store.StoreName);
        }
    }
}