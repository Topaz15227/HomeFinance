using HomeFinance.Application.Tests.Infrastructure;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using System.Collections.Generic;
using HomeFinance.Application.StorePays.Queries;
using HomeFinance.Domain.Entities;
namespace HomeFinance.Application.Tests.StorePays.Queries
{
    [Collection("QueryCollection")]
    public class GetStorePaysByClosingQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetStorePaysByClosingQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetStorePaysByClosingQuery()
        {
            var qh = new GetStorePaysByClosingQueryHandler(_context);

            var result = await qh.Handle(new GetStorePaysByClosingQuery { ClosingId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<ClosingPayListViewModel>();

            result.RowCount.ShouldBe(2);
        }
    }
}
