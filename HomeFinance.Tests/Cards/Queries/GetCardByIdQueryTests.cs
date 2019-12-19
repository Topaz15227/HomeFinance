using HomeFinance.Application.Cards.Queries;
using HomeFinance.Application.Tests.Infrastructure;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using HomeFinance.Domain.Entities;

namespace HomeFinance.ApplicationTests.Cards.Queries
{
    [Collection("QueryCollection")]
    public class GetCardByIdQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetCardByIdQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetCardByIdQuery()
        {
            var qh = new GetCardByIdQueryHandler(_context);

            var result = await qh.Handle(new GetCardByIdQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<Card>();

            result.CardName.ShouldBe("AM");

        }
    }
}
