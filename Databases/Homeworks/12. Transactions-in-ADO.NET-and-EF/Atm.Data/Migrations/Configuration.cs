namespace Atm.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<AtmDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "Atm.Data.AtmDbContext";
        }

        protected override void Seed(AtmDbContext context)
        {
        }
    }
}