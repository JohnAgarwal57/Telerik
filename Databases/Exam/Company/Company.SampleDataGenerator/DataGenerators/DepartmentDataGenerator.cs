namespace Company.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Company.Data;
    using Interfaces;
   
    internal class DepartmentDataGenerator : DataGenerator, IDataGenerator
    {
        private const int MinimalDepartmentNameLength = 10;
        private const int MaxmimalDepartmentNameLength = 50;

        public DepartmentDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding departments");
            var uniqueDepartmentNames = new HashSet<string>();
            var count = 0;

            while (uniqueDepartmentNames.Count != this.Count)
            {
                uniqueDepartmentNames.Add(this.Random.GetRandomStringWithRandomLength(MinimalDepartmentNameLength, MaxmimalDepartmentNameLength));
            }

            foreach (var departmentName in uniqueDepartmentNames)
            {
                var department = new Department
                {
                    DepartmentName = departmentName
                }; 

                this.Database.Departments.Add(department);

                count++;

                if (count % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }
            }

            Console.WriteLine("\nDepartments added");
        }
    }
}
