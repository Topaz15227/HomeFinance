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
    public class GetStorePaysQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetStorePaysQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetStorePaysQuery()
        {
            var qh = new GetStorePaysQueryHandler(_context);

            var result = await qh.Handle(new GetStorePaysQuery { }, CancellationToken.None);

            result.ShouldBeOfType<List<ViewStorePays>>();

            result.Count.ShouldBeGreaterThan(1);
        }
    }
}
