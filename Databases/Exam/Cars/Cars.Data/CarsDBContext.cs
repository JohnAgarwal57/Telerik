namespace Cars.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Cars.Data.Migrations;
    using Cars.Models;

    public class CarsDBContext : DbContext, ICarsDBContext
    {
        public CarsDBContext()
            : base("CarsConnectionExpress")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDBContext, Configuration>());
        }

        public CarsDBContext(string connection)
            : base(connection)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDBContext, Configuration>());
        }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<City> Cities { get; set; }

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
