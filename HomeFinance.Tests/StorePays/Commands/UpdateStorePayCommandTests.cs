using HomeFinance.Application.StorePays.Commands;
using System.Threading;
using System.Threading.Tasks;
using HomeFinance.Persistence;
using Xunit;
using HomeFinance.Application.Tests.Infrastructure;
//using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.Tests.StorePays.Commands
{
    public class UpdateStorePayCommandTests : TestBase
    {
        private readonly HomeFinanceDbContext _context;
        private readonly UpdateStorePayCommandHandler _commandHandler;

        public UpdateStorePayCommandTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
            _commandHandler = new UpdateStorePayCommandHandler(_context);
        }

        [Fact]
        public async Task UpdateStorePayCommandTest()
        {
            var origStorePay = await _context.StorePays.FindAsync(3);
            // Arrange
            var command = new UpdateStorePayCommand
            {
                Id = 3,
                PayDate = origStorePay.PayDate,
                CardId = origStorePay.CardId,
                StoreId = origStorePay.StoreId,
                Amount = origStorePay.Amount,
                Note = origStorePay.Note,
                ClosingId = origStorePay.ClosingId,
                Active = false
            };

            // Act
            await _commandHandler.Handle(command, CancellationToken.None);

            var storePay = await _context.StorePays.FindAsync(command.Id);

            // Assert
            // Assert.Equal(command.Active, store.Active);
            Assert.False(command.Active);
        }
    }
}