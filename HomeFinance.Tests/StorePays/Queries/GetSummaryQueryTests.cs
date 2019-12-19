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
    public class GetSummaryQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetSummaryQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetSummaryQuery()
        {
            var qh = new GetSummaryQueryHandler(_context);

            var result = await qh.Handle(new GetSummaryQuery { }, CancellationToken.None);

            result.ShouldBeOfType<List<ViewCardPays>>();

            result.Count.ShouldBeGreaterThan(1);
            result[0].CardName.ShouldBe("All");
        }
    }
}
