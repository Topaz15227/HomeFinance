using HomeFinance.Application.Tests.Infrastructure;
using HomeFinance.Persistence;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using System.Collections.Generic;
using HomeFinance.Application.Cards.Queries;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Application.Tests.Cards.Queries
{
    [Collection("QueryCollection")]
    public class GetCardsQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetCardsQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetCardsQuery()
        {
            var qh = new GetCardsQueryHandler(_context);

            var result = await qh.Handle(new GetCardsQuery { }, CancellationToken.None);

            result.ShouldBeOfType<List<Card>>();

            result.Count.ShouldBeGreaterThan(2);
            result.Count.ShouldBe(3);
        }
    }
}
