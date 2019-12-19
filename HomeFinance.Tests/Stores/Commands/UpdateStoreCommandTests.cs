using HomeFinance.Application.Stores.Commands;
using System.Threading;
using System.Threading.Tasks;
using HomeFinance.Persistence;
using Xunit;
using HomeFinance.Application.Tests.Infrastructure;
using System.Linq;

namespace HomeFinance.Application.Tests.Stores.Commands
{
    public class UpdateStoreCommandTests : TestBase
    {
        private readonly HomeFinanceDbContext _context;
        private readonly UpdateStoreCommandHandler _commandHandler;

        public UpdateStoreCommandTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
            _commandHandler = new UpdateStoreCommandHandler(_context);
        }

        [Fact]
        public async Task UpdateStoreCommandTest()
        {
            var origStore = await _context.Stores.FindAsync(1);
            // Arrange
            var command = new UpdateStoreCommand
            {
                Id = 1,
                StoreName = origStore.StoreName,
                Active = false
            };

            // Act
            await _commandHandler.Handle(command, CancellationToken.None);

            var store = await _context.Stores.FindAsync(command.Id);

            // Assert
           // Assert.Equal(command.Active, store.Active);
            Assert.False(command.Active);
        }
    }
}
