namespace Atm.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Atm.Data.Migrations;
    using Atm.Models;
    
    public class AtmDbContext : DbContext
    {
        public AtmDbContext()
        : base("AtmConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtmDbContext, Configuration>());
        }

        public DbSet<CardAccount> CardAccounts { get; set; }

        public DbSet<TransactionsHistory> TransactionsHistories { get; set; }
    }
}
