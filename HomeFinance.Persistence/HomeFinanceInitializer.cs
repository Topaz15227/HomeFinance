using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HomeFinance.Domain.Entities;

namespace HomeFinance.Persistence
{
    public class HomeFinanceInitializer
    {
        //private readonly Dictionary<int, Card> Cards = new Dictionary<int, Card>();
        //private readonly Dictionary<int, Store> Stores = new Dictionary<int, Store>();

        public static void Initialize(HomeFinanceDbContext context)
        {
            var initializer = new HomeFinanceInitializer();
            initializer.SeedEverything(context);  //comment if need DB tables without data
        }

        public void SeedEverything(HomeFinanceDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Cards.Any())
            {
                return; // Db has been seeded
            }

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
                new Store {StoreName="Giant"},
                new Store {StoreName="Cvs"},
                new Store {StoreName="Safeway"},
                new Store {StoreName="Occasional"},
                new Store {StoreName="Fuel"}
            };
            context.Stores.AddRange(stores);

            context.SaveChanges();
        }
    }
}
