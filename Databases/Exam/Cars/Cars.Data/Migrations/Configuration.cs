namespace Cars.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<CarsDBContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "Clinics.Data.ClinicsDBContex";
        }

        protected override void Seed(CarsDBContext context)
        {
        }
    }
}