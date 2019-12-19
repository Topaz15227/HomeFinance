using HomeFinance.Application.Tests.Infrastructure;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using System.Collections.Generic;
using HomeFinance.Application.Stores.Queries;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.Tests.Stores.Queries
{
    [Collection("QueryCollection")]
    public class GetStoresQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetStoresQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetStoresQuery()
        {
            var qh = new GetStoresQueryHandler(_context);

            var result = await qh.Handle(new GetStoresQuery { PageNumber = 1, PageSize = 10 }, CancellationToken.None);

            result.ShouldBeOfType<StoreListModel>();

            result.RowCount.ShouldBe(5);
        }
    }
}
