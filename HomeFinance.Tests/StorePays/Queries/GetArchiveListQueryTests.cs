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
    public class GetArchiveListQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetArchiveListQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetArchiveListQuery()
        {
            var qh = new GetArchiveListQueryHandler(_context);

            var result = await qh.Handle(new GetArchiveListQuery { CardId = 0, Filter = "", SortBy = "CardName", SortOrder = "asc" }, CancellationToken.None);

            result.ShouldBeOfType<ArchiveListViewModel>();

            result.ArchiveListData.Count.ShouldBe(2);
        }

        [Fact]
        public async Task GetStorePayFilteredListQuery()
        {
            var qh = new GetArchiveListQueryHandler(_context);

            var result = await qh.Handle(new GetArchiveListQuery { CardId = 0, Filter = "Giant" }, CancellationToken.None);
            //var result = await qh.Handle(new GetArchiveListQuery { CardId = 0, Filter = "CH"}, CancellationToken.None);

            result.ShouldBeOfType<ArchiveListViewModel>();

            result.ArchiveListData.Count.ShouldBe(1);
            result.ArchiveListData[0].CardName.ShouldBe("AM");
        }

    }
}