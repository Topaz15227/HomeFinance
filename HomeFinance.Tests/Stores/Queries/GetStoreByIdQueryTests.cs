using HomeFinance.Application.Stores.Queries;
using HomeFinance.Application.Tests.Infrastructure;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using HomeFinance.Domain.Entities;

namespace HomeFinance.ApplicationTests.Stores.Queries
{
    [Collection("QueryCollection")]
    public class GetStoreByIdQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetStoreByIdQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetStoreByIdQuery()
        {
            var qh = new GetStoreByIdQueryHandler(_context);

            var result = await qh.Handle(new GetStoreByIdQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<Store>();

            result.StoreName.ShouldBe("Giant");

        }
    }
}
