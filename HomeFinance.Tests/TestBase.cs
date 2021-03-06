﻿using HomeFinance.Application.Tests.Infrastructure;
using HomeFinance.Persistence;

namespace HomeFinance.Application.Tests
{
    public class TestBase
    {
        public HomeFinanceDbContext GetDbContext()
        {
            var dbContext = HomeFinanceDbContextFactory.CreateAsync("HFTests").Result;

            return dbContext;
        }
    }
}
