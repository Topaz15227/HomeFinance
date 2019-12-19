using HomeFinance.Application.Tests.Infrastructure;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using HomeFinance.Application.StorePays.Queries;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.Tests.StorePays.Queries
{
    [Collection("QueryCollection")]
    public class GetCardPayQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetCardPayQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetAllCardsPayQuery()
        {
            var qh = new GetCardPayQueryHandler(_context);

            var result = await qh.Handle(new GetCardPayQuery { CardId = 0 }, CancellationToken.None);

            result.ShouldBeOfType<ViewCardPays>();

            result.NumOfPays.ShouldBe(5);
            result.CardName.ShouldBe("All");
        }

        [Fact]
        public async Task GetCardPayQuery()
        {
            var qh = new GetCardPayQueryHandler(_context);

            var result = await qh.Handle(new GetCardPayQuery { CardId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<ViewCardPays>();

            result.NumOfPays.ShouldBe(2);
            result.CardName.ShouldBe("AM");
        }
    }
}