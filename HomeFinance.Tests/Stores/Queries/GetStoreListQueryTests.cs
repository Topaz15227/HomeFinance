using HomeFinance.Application.Tests.Infrastructure;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using System.Collections.Generic;
using HomeFinance.Application.Stores.Queries;

namespace HomeFinance.Application.Tests.Stores.Queries
{
    [Collection("QueryCollection")]
    public class GetStoreListQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetStoreListQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetActiveStoreListQuery()
        {
            var qh = new GetStoreListQueryHandler(_context);

            var result = await qh.Handle(new GetStoreListQuery { }, CancellationToken.None);

            result.ShouldBeOfType<List<StoreListViewModel>>();

            result.Count.ShouldBe(4);
            result[0].StoreName.ShouldBe("Giant");
        }
    }
}
