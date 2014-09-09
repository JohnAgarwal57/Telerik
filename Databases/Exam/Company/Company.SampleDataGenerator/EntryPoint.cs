namespace Company.SampleDataGenerator
{
    using System.Collections.Generic;

    using Data;
    using DataGenerators;
    using Interfaces;

    internal class EntryPoint
    {
        private static void Main()
        {
            var random = RandomDataGenerator.Instance;
            var db = new CompanyEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>
            {
               new DepartmentDataGenerator(random, db, 100),
               new EmployeesDataGenerator(random, db, 5000),
               new ProjectsDataGenerator(random, db, 1000),
               new EmployeesProjectsDataGenerator(random, db, 1000),
               new ReportsDataGenerator(random, db, 250000)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }
        }
    }
}
