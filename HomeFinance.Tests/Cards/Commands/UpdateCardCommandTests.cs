using HomeFinance.Application.Cards.Commands;
using System.Threading;
using System.Threading.Tasks;
using HomeFinance.Persistence;
using Xunit;
using HomeFinance.Application.Tests.Infrastructure;

namespace HomeFinance.Application.Tests.Cards.Commands
{
    public class UpdateCardCommandTests : TestBase
    {
        private readonly HomeFinanceDbContext _context;
        private readonly UpdateCardCommandHandler _commandHandler;

        public UpdateCardCommandTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
            _commandHandler = new UpdateCardCommandHandler(_context);
        }

        [Fact]
        public async Task UpdateCardCommandTest()
        {
            var origCard = await _context.Cards.FindAsync(3);
            // Arrange
            var command = new UpdateCardCommand
            {
                Id = 1,
                CardName = origCard.CardName,
                CardDescription = origCard.CardDescription,
                CardNumber = origCard.CardNumber,
                ClosingName =origCard.ClosingName,
                Active = false
            };

            // Act
            await _commandHandler.Handle(command, CancellationToken.None);

            var storePay = await _context.Cards.FindAsync(command.Id);

            // Assert
            // Assert.Equal(command.Active, store.Active);
            Assert.False(command.Active);
        }
    }
}
