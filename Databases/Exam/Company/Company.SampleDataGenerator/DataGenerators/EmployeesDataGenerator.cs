namespace Company.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Linq;

    using Data;
    using Interfaces;
    
    internal class EmployeesDataGenerator : DataGenerator, IDataGenerator
    {
        private const int MinimalNameLength = 5;
        private const int MaximalNameLength = 20;
        private const int MinimalSalaryValue = 50000;
        private const int MaximalSalaryValue = 200000;
        private const int PercentOfEmpoyeeWithManager = 95;

        public EmployeesDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            var departmentsIds = this.Database.Departments.Select(d => d.Id).ToList();

            Console.WriteLine("Adding Employees");
            for (int i = 0; i < this.Count; i++)
            {
                var managersIds = this.Database.Employees.Where(e => e.ManagerId == null).ToList();
                int? managerId;

                var employee = new Employee
                {
                    FirstName = this.Random.GetRandomStringWithRandomLength(MinimalNameLength, MaximalNameLength),
                    LastName = this.Random.GetRandomStringWithRandomLength(MinimalNameLength, MaximalNameLength),
                    YearSalary = this.Random.GetRandomNumber(MinimalSalaryValue, MaximalSalaryValue),
                    DepartmentId = departmentsIds[this.Random.GetRandomNumber(0, departmentsIds.Count - 1)],                   
                };

                if ((this.Random.GetRandomNumber(0, 100) < PercentOfEmpoyeeWithManager) && (managersIds.Count > 0))
                {
                    managerId = managersIds[this.Random.GetRandomNumber(0, managersIds.Count - 1)].Id;
                }
                else
                {
                    managerId = null;
                }

                employee.ManagerId = managerId;

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Employees.Add(employee);
            }
            
            Console.WriteLine("\nEmployees added");
        }
    }
}
