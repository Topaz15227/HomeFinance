using HomeFinance.Application.Tests.Infrastructure;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using HomeFinance.Application.Closings.Queries;

namespace HomeFinance.Application.Tests.Closings.Queries
{
    [Collection("QueryCollection")]
    public class GetClosingsQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetClosingsQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetClosingsQuery()
        {
            var qh = new GetClosingsQueryHandler(_context);

            var result = await qh.Handle(new GetClosingsQuery { CardId = 0, SortBy = "CardName", SortOrder = "asc" }, CancellationToken.None);

            result.ShouldBeOfType<ClosingListViewModel>();

            result.RowCount.ShouldBe(1);
        }
    }
}
