using HomeFinance.Application.Tests.Infrastructure;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using HomeFinance.Application.Closings.Queries;

namespace HomeFinance.ApplicationTests.Closings.Queries
{
    [Collection("QueryCollection")]
    public class GetNextClosingNumberQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetNextClosingNumberQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetNextClosingNumber()
        {
            var qh = new GetNextClosingNumberQueryHandler(_context);

            var result = await qh.Handle(new GetNextClosingNumberQuery { CardId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<string>();

            result.ShouldBe("am-2");

        }
    }
}