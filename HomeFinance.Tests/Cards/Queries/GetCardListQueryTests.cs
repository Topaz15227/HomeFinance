using HomeFinance.Application.Tests.Infrastructure;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using System.Collections.Generic;
using HomeFinance.Application.Cards.Queries;

namespace HomeFinance.Application.Tests.Cards.Queries
{
    [Collection("QueryCollection")]
    public class GetCardListQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetCardListQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetActiveCardListQuery()
        {
            var qh = new GetCardListQueryHandler(_context);

            var result = await qh.Handle(new GetCardListQuery { }, CancellationToken.None);

            result.ShouldBeOfType<List<CardListViewModel>>();

            result.Count.ShouldBe(2);
            result[0].CardName.ShouldBe("AM");
        }
    }
}