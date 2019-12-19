using HomeFinance.Application.Cards.Commands;
using System.Threading;
using System.Threading.Tasks;
using HomeFinance.Persistence;
using Xunit;
using HomeFinance.Application.Tests.Infrastructure;
using System.Linq;
using System;

namespace HomeFinance.Application.Tests.Cards.Commands
{
    public class AddCardCommandTests : TestBase
    {
        private readonly HomeFinanceDbContext _context;
        private readonly AddCardCommandHandler _commandHandler;

        public AddCardCommandTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
            _commandHandler = new AddCardCommandHandler(_context);
        }

        [Fact]
        public async Task AddCardCommandTest()
        {
            // Arrange
            var command = new AddCardCommand
            {
                CardName = "ABCCard",
                CardDescription = "ABC Card",
                CardNumber = "AC *1357",
                ClosingName="abc",
                Active = true
            };

            // Act
            var id = await _commandHandler.Handle(command, CancellationToken.None);

            var store = await _context.Cards.FindAsync(id);

            // Assert
            Assert.Equal(command.CardName, store.CardName);
        }
    }
}
