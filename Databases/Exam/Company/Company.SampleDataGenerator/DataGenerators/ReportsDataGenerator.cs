namespace Company.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Linq;

    using Data;
    using Interfaces;

    internal class ReportsDataGenerator : DataGenerator, IDataGenerator
    {
        private const int MinimalNumberOfEmployeeInProject = 40;
        private const int MaximalNumberOfEmployeeInProject = 60;
        private const int MinutesToAdd = 241;

        public ReportsDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {          
            var employeesIds = this.Database.Employees.Select(e => e.Id).ToList();
            int index = 0;

            Console.WriteLine("Adding Reports");

            foreach (var employee in employeesIds)
            {    
                var time = this.Random.GetRandomDate().AddHours(7).AddMinutes(this.Random.GetRandomNumber(0, MinutesToAdd));

                var numberOfReportsPerEmployee = this.Random.GetRandomNumber(MinimalNumberOfEmployeeInProject, MaximalNumberOfEmployeeInProject);

                for (int i = 0; i < numberOfReportsPerEmployee; i++)
                {
                    var report = new Report
                    {
                        EmployeeId = employee,
                        ReportingTime = time
                    };

                    this.Database.Reports.Add(report);

                    index++;
                    if (index % 100 == 0)
                    {
                        Console.Write(".");
                        this.Database.SaveChanges();
                    }                   
                }
            }

            Console.WriteLine("\nReports added");
        }
    }
}
