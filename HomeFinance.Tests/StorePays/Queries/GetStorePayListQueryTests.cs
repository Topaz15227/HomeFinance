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
    public class GetStorePayListQueryTests
    {
        private readonly HomeFinanceDbContext _context;

        public GetStorePayListQueryTests()
        {
            _context = HomeFinanceDbContextFactory.CreateAsync().Result;
        }

        [Fact]
        public async Task GetStorePayListQuery()
        {
            var qh = new GetStorePayListQueryHandler(_context);

             var result = await qh.Handle(new GetStorePayListQuery { CardId = 2 }, CancellationToken.None);

            result.ShouldBeOfType<StorePayListViewModel>();

            result.ListData.Count.ShouldBe(3);
        }

        [Fact]
        public async Task GetStorePayFilteredListQuery()
        {
            var qh = new GetStorePayListQueryHandler(_context);

            var result = await qh.Handle(new GetStorePayListQuery { CardId =0, Filter = "Giant", SortBy="CardName", SortOrder="asc"}, CancellationToken.None);
            //var result = await qh.Handle(new GetStorePayListQuery { CardId = 0, Filter = "CH"}, CancellationToken.None);

            result.ShouldBeOfType<StorePayListViewModel>();

            result.ListData.Count.ShouldBe(2);
            result.ListData[0].CardName.ShouldBe("AM");
        }

        [Fact]
        public async Task GetStorePayPagedListQuery()
        {
            var qh = new GetStorePayListQueryHandler(_context);

            var result = await qh.Handle(new GetStorePayListQuery { CardId=0, PageNumber=2, PageSize=3 }, CancellationToken.None);

            result.ShouldBeOfType<StorePayListViewModel>();

            result.ListData.Count.ShouldBe(2);

        }
    }
}