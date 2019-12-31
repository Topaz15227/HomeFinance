using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeFinance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeFinance.Persistence
{
    public class HomeFinanceInitializer
    {
        public static void Initialize(HomeFinanceDbContext context)
        {
            var initializer = new HomeFinanceInitializer();

            context.Database.EnsureCreated();

            if (!context.Cards.Any())
            {
                initializer.CreateViews(context);

                initializer.SeedMainData(context);  //comment if need DB tables without data
            }
        }

        public void CreateViews(HomeFinanceDbContext context)
        {
            context.Database.ExecuteSqlRaw(@"
CREATE view [dbo].[ViewCardPays]
as
(SELECT 0 as Id, 'All' as CardName,
(select Count(Id) from StorePays where ClosingId is null)  as NumOfPays,
(select isnull(SUM(Amount),0) from StorePays where ClosingId is null) as Total,
(select isnull(SUM(Amount),0) from StorePays where ClosingId is null and Active=1) as ActiveTotal)
Union
(SELECT c.Id,c.CardName,
(select Count(sp.Id) from StorePays sp where sp.CardId=c.Id and sp.ClosingId is null)  as NumOfPays,
(select isnull(SUM(sp.Amount),0) from StorePays sp where sp.CardId=c.Id and sp.ClosingId is null) as Total,
(select isnull(SUM(sp.Amount),0) from StorePays sp where sp.CardId=c.Id and sp.ClosingId is null and sp.Active=1) as ActiveTotal
FROM Cards c
WHERE c.Active = 1)
");

                context.Database.ExecuteSqlRaw(@"
CREATE view [dbo].[ViewClosings]
as
SELECT cl.Id, c.CardName, cl.ClosingDate, cl.ClosingName, cl.ClosingAmount, cl.CardId
FROM Closings cl
	LEFT JOIN Cards c on cl.CardId = c.Id
");

                context.Database.ExecuteSqlRaw(@"
CREATE view [dbo].[ViewStorePays]
as
SELECT sp.Id, c.CardName,sp.PayDate, s.StoreName, sp.Amount, isnull(sp.Note, '') as Note,
	cl.ClosingDate, isnull(sp.Active, 0) as Active, sp.CardId, sp.StoreId, sp.ClosingId
FROM StorePays sp
	LEFT JOIN Cards c on sp.CardId = c.Id
	LEFT JOIN Stores s on sp.StoreId = s.Id
	LEFT JOIN Closings cl on sp.ClosingId = cl.Id
");
        }

        public void SeedMainData(HomeFinanceDbContext context)
        {

            SeedCards(context);

            SeedStores(context);
        }
        public void SeedCards(HomeFinanceDbContext context)
        {
            var cards = new[]
            {
                new Card {  CardName="MasterCard", CardDescription="Master Card", CardNumber="MC *1234", ClosingName="mc"},
                new Card {  CardName="Visa", CardDescription="Visa Card", CardNumber="V *4321", ClosingName="vc"},
                new Card {  CardName="BankCard", CardDescription="Bank Card", CardNumber="BC *1221", ClosingName="bc", Active=false}
           };
            context.Cards.AddRange(cards);

            context.SaveChanges();
        }

        public void SeedStores(HomeFinanceDbContext context)
        {
            var stores = new[]
            {
                new Store {StoreName="Occasional"},
                new Store {StoreName="Giant"},
                new Store {StoreName="Safeway"},
                new Store {StoreName="Cvs"},
                new Store {StoreName="Fuel"}
            };
            context.Stores.AddRange(stores);

            context.SaveChanges();
        }
    }
}
