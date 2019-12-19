using HomeFinance.Application.StorePays.Commands;
using System.Threading;
using System.Threading.Tasks;
using HomeFinance.Persistence;
using Xunit;
using HomeFinance.Application.Tests.Infrastructure;
using System.Linq;
using System;

namespace HomeFinance.Application.Tests.StorePays.Commands
{
    public class AddStorePayCommandTests : TestBase
    {
        private readonly HomeFinanceDbContext _context;
        private readonly AddStorePayCommandHandler _commandHandler;

        public AddStorePayCommandTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
            _commandHandler = new AddStorePayCommandHandler(_context);
        }

        [Fact]
        public async Task AddStorePayCommandTest()
        {
            // Arrange
            var command = new AddStorePayCommand
            {
                PayDate = DateTime.Now,
                CardId=1,
                StoreId=1,
                Amount=5.75m,
                Note="Just Note",
                ClosingId=null,
                Active = true
            };

            // Act
            var id = await _commandHandler.Handle(command, CancellationToken.None);

            var store = await _context.StorePays.FindAsync(id);

            // Assert
            Assert.Equal(command.Note, store.Note);
        }
    }
}