using HomeFinance.Application.Closings.Queries;
using HomeFinance.Application.Tests.Infrastructure;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using HomeFinance.Domain.Entities;

namespace HomeFinance.ApplicationTests.Closings.Queries
{
    [Collection("QueryCollection")]
    public class GetClosingViewByIdQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetClosingViewByIdQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetClosingViewByIdQuery()
        {
            var qh = new GetClosingViewByIdQueryHandler(_context);

            var result = await qh.Handle(new GetClosingViewByIdQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<ClosingViewModel>();

            result.CardName.ShouldBe("AM");

        }
    }
}