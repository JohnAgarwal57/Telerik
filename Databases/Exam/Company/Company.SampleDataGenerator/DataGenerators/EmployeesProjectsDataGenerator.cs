namespace Company.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Linq;

    using Data;
    using Interfaces;

    internal class EmployeesProjectsDataGenerator : DataGenerator, IDataGenerator
    {
        private const int MinimumEmployeeInProject = 2;
        private const int MaximumEmployeeInProject = 20;
        private const int MinimumEndDayDifference = 1;
        private const int MaximumEndDayDifference = 100;

        public EmployeesProjectsDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {          
            var projectsIds = this.Database.Projects.Select(p => p.Id).ToList();
            int index = 0;

            Console.WriteLine("Adding EmployeesProjects");

            foreach (var project in projectsIds)
            {                
                var employeesIds = this.Database.Employees.Select(e => e.Id).ToList();
                
                var startDate = this.Random.GetRandomDate();
                var endDate = startDate.AddDays(this.Random.GetRandomNumber(MinimumEndDayDifference, MaximumEndDayDifference));

                var currentCount = this.Random.GetRandomNumber(MinimumEmployeeInProject, MaximumEmployeeInProject);
                var exists = new int[employeesIds.Count + 1];

                for (int i = 0; i < currentCount; i++)
                {
                    var currentEmployeeId = this.Random.GetRandomNumber(0, employeesIds.Count - 1);

                    while (exists[currentEmployeeId] == 1)
                    {
                        currentEmployeeId = this.Random.GetRandomNumber(0, employeesIds.Count - 1);
                    }

                    exists[currentEmployeeId] = 1;

                    var employeeProject = new EmployeesProject
                    {
                        ProjectId = project,
                        StartDate = startDate,
                        EndDate = endDate,
                        EmployeeId = employeesIds[currentEmployeeId]
                    };

                    this.Database.EmployeesProjects.Add(employeeProject);

                    index++;
                    if (index % 100 == 0)
                    {
                        Console.Write(".");
                        this.Database.SaveChanges();
                    }                   
                }
            }

            Console.WriteLine("\nEmployeesProjects added");
        }
    }
}
