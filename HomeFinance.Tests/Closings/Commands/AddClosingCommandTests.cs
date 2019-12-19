using HomeFinance.Application.Closings.Commands;
using System.Threading;
using System.Threading.Tasks;
using HomeFinance.Persistence;
using Xunit;
using HomeFinance.Application.Tests.Infrastructure;
using System.Linq;
using System;

namespace HomeFinance.Application.Tests.Closings.Commands
{
    public class AddClosingCommandTests : TestBase
    {
        private readonly HomeFinanceDbContext _context;
        private readonly AddClosingCommandHandler _commandHandler;

        public AddClosingCommandTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
            _commandHandler = new AddClosingCommandHandler(_context);
        }

        [Fact]
        public async Task AddClosingCommandTest()
        {
            // Arrange
            var command = new AddClosingCommand
            {
                ClosingDate = DateTime.Now,
                CardId = 2,
                ClosingName = "y1",
                ClosingAmount = 60.10m
            };

            // Act
            var id = await _commandHandler.Handle(command, CancellationToken.None);

            var closing = await _context.Closings.FindAsync(id);

            // Assert
            Assert.Equal(command.ClosingAmount, closing.ClosingAmount);

        }
    }
}
