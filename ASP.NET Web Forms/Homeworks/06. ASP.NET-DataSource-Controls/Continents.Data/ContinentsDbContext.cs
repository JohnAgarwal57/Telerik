namespace Continents.Data
{
    using System.Data.Entity;

    using Continents.Data.Migrations;
    using Continents.Models;

    public class ContinentsDbContext : DbContext
    {
        public ContinentsDbContext()
            : base("ContinentsConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContinentsDbContext, Configuration>());
        }

        public IDbSet<Continent> Continents { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Town> Towns { get; set; }

        public IDbSet<Language> Languages { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new void Dispose()
        {
            base.Dispose();
        }

        public void AutoDetectChanges(bool set)
        {
            this.Configuration.AutoDetectChangesEnabled = set;
        }
    }
}
