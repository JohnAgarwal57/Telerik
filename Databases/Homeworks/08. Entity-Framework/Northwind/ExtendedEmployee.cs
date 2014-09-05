namespace Northwind
{
    using System.Data.Entity;

    class ExtendedEmployee : Employee
    {
        public DbSet<Territory> Territory { get; set; }
    }
}
