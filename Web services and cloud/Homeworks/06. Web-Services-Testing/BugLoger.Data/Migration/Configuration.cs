namespace BugLogger.Data.Migration
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<BugLoggerDBContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "BugLoger.Data.BugLoggerDBContext";
        }

        protected override void Seed(BugLoggerDBContext context)
        {
        }
    }
}
