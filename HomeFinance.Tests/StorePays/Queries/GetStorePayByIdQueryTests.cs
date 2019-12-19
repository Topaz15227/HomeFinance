using HomeFinance.Application.StorePays.Queries;
using HomeFinance.Application.Tests.Infrastructure;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using HomeFinance.Domain.Entities;

namespace HomeFinance.ApplicationTests.StorePays.Queries
{
    [Collection("QueryCollection")]
    public class GetStorePayByIdQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetStorePayByIdQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetStorePayByIdQuery()
        {
            var qh = new GetStorePayByIdQueryHandler(_context);

            var result = await qh.Handle(new GetStorePayByIdQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<StorePay>();

            result.CardId.ShouldBe(1);
            result.Amount.ShouldBe(25.25m);

        }
    }
}