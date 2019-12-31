using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using HomeFinance.Domain.Entities;
using HomeFinance.Persistence.Configurations;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using JetBrains.Annotations;

namespace HomeFinance.Persistence
{
    public class HomeFinanceDbContext : DbContext
    {
        private readonly IConfiguration _config;

        //private SqlConnection _sqlConnection;

        //public HomeFinanceDbContext(DbContextOptions options) : base(options)
        //{
        //}

        public HomeFinanceDbContext(DbContextOptions<HomeFinanceDbContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        _sqlConnection = new SqlConnection(_config.GetConnectionString("HomeFinanceDatabase"));
        //        //_sqlConnection.StateChange += Connection_StateChange;

        //        optionsBuilder.UseSqlServer(_sqlConnection);
        //    }

        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<Card> Cards { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<StorePay> StorePays { get; set; }

        public DbSet<Closing> Closings { get; set; }

        public DbSet<ViewStorePays> ViewStorePays { get; set; }

        public DbSet<ViewCardPays> ViewCardPays { get; set; }

        public DbSet<ViewClosings> ViewClosings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HomeFinanceDbContext).Assembly);
        }
    }
}

