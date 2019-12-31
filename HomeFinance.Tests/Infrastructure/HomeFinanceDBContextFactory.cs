using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HomeFinance.Domain.Entities;
using HomeFinance.Persistence;

namespace HomeFinance.Application.Tests.Infrastructure
{
    public class HomeFinanceDbContextFactory
    {
        public static async Task<HomeFinanceDbContext> CreateAsync(string dbName = null)
        {
            var connection = new Microsoft.Data.Sqlite.SqliteConnection("DataSource=:memory:");
            connection.Open();

            var dbOptions = new DbContextOptionsBuilder<HomeFinanceDbContext>()
                .UseSqlite(connection)
                .Options;

            var _context = new HomeFinanceDbContext(dbOptions, null); //config

            var r = await _context.Database.EnsureCreatedAsync();

            CreateData(ref _context);

            return _context;
        }


        private static void CreateData(ref HomeFinanceDbContext _context)
        {
            const int NUM_OF_IDS = 100;
            List<int> ids = new List<int>();
            for (var i = 1; i < NUM_OF_IDS; i++)
                ids.Add(i);

            if(!_context.Cards.Any(c => ids.Contains(c.Id)))
            {
                _context.Cards.AddRange(new[]
                {
                    new Card {  Id=1, CardName="AM", CardDescription="Visa Amazon", CardNumber="AM *1234", ClosingName="am"},
                    new Card {  Id=2, CardName="CH", CardDescription="MC Chase", CardNumber="CH *4321", ClosingName="ch"},
                    new Card {  Id=3, CardName="BoA", CardDescription="Bank of America", CardNumber="BoA *1221", Active=false, ClosingName="boa"},
                });
            }

            if(!_context.Stores.Any(s => ids.Contains(s.Id)))
            {
                _context.Stores.AddRange(new[]
                {
                    new Store { Id=1, StoreName="Giant"},
                    new Store { Id=2, StoreName="Whole Foods"},
                    new Store { Id=3, StoreName="Cvs", Active = false},
                    new Store { Id=4, StoreName="Trader Joe's"},
                    new Store { Id=5, StoreName="Safeway"}
                });
            }

            if(!_context.Closings.Any(c => ids.Contains(c.Id)))
            {
                _context.Closings.Add(new Closing { Id = 1, CardId = 1, ClosingDate = DateTime.Parse("07/27/2019"),
                    ClosingName ="am-1" , ClosingAmount = 62.82m}); 

            }

            var r = _context.SaveChangesAsync().Result;

            if (!_context.StorePays.Any(p => ids.Contains(p.Id)))
            {
                _context.StorePays.AddRange(new[]
                {
                    new StorePay { Id=1, CardId=1, StoreId=1, PayDate = DateTime.Parse("07/07/2019"), Amount = 25.25m, ClosingId = 1, Active=false},
                    new StorePay { Id=2, CardId=1, StoreId=4, PayDate = DateTime.Parse("07/15/2019"), Amount = 37.57m, ClosingId = 1, Active=false},
                    new StorePay { Id=3, CardId=2, StoreId=1, PayDate = DateTime.Parse("07/28/2019"), Amount = 45.25m, Active=true},
                    new StorePay { Id=4, CardId=2, StoreId=3, PayDate = DateTime.Parse("08/05/2019"), Amount = 27.25m, Active=false},
                    new StorePay { Id=5, CardId=2, StoreId=5, PayDate = DateTime.Parse("08/15/2019"), Amount = 15.85m, Active=true},
                    new StorePay { Id=6, CardId=1, StoreId=1, PayDate = DateTime.Parse("08/25/2019"), Amount = 17.25m, Active=true},
                    new StorePay { Id=7, CardId=1, StoreId=5, PayDate = DateTime.Parse("08/27/2019"), Amount = 25.85m, Active=true}
                });
            }

            r = _context.SaveChangesAsync().Result;

            _context.Database.ExecuteSqlRaw(@"
INSERT INTO ViewStorePays (Id, CardName, PayDate, StoreName, Amount, Note,
    ClosingDate, Active, CardId, StoreId, ClosingId)
SELECT sp.Id, c.CardName,sp.PayDate, s.StoreName, sp.Amount, sp.Note,
	cl.ClosingDate, sp.Active, sp.CardId, sp.StoreId, sp.ClosingId
FROM StorePays sp
	LEFT JOIN Cards c on sp.CardId = c.Id
	LEFT JOIN Stores s on sp.StoreId = s.Id
	LEFT JOIN Closings cl on sp.ClosingId = cl.Id"
);

            _context.Database.ExecuteSqlRaw(@"
INSERT INTO  ViewClosings(Id, CardName, ClosingDate, ClosingName, ClosingAmount, CardId)
SELECT cl.Id, c.CardName, cl.ClosingDate, cl.ClosingName, cl.ClosingAmount, cl.CardId
FROM Closings cl
    LEFT JOIN Cards c on cl.CardId = c.Id"
);

            _context.Database.ExecuteSqlRaw(@"
INSERT INTO  ViewCardPays (Id, CardName, NumOfPays, Total, ActiveTotal)
SELECT 0 as Id, 'All' as CardName,
(select Count(Id) from StorePays where ClosingId is null) as NumOfPays,
(select ifnull(SUM(Amount),0) from StorePays where ClosingId is null) as Total,
(select ifnull(SUM(Amount),0) from StorePays where ClosingId is null and Active=1) as ActiveTotal
Union
SELECT c.Id,c.CardName,
(select Count(sp.Id) from StorePays sp where sp.CardId=c.Id and sp.ClosingId is null)  as NumOfPays,
(select ifnull(SUM(sp.Amount),0) from StorePays sp where sp.CardId=c.Id and sp.ClosingId is null) as Total,
(select ifnull(SUM(sp.Amount),0) from StorePays sp where sp.CardId=c.Id and sp.ClosingId is null and sp.Active=1) as ActiveTotal
FROM Cards c
WHERE c.Active = 1"
);

        }

	}
}


