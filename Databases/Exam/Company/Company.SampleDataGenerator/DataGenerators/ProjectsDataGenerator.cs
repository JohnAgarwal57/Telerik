namespace Company.SampleDataGenerator.DataGenerators
{
    using System;
    using System.Linq;

    using Data;
    using Interfaces;

    internal class ProjectsDataGenerator : DataGenerator, IDataGenerator
    {
        private const int MinimalNameLength = 5;
        private const int MaximalNameLength = 50;

        public ProjectsDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding Projects");
            for (int i = 0; i < this.Count; i++)
            {
                var project = new Project
                {
                    Name = this.Random.GetRandomStringWithRandomLength(MinimalNameLength, MaximalNameLength)
                };

                if (i % 100 == 0)
                {
                    Console.Write(".");
                    this.Database.SaveChanges();
                }

                this.Database.Projects.Add(project);
            }
            
            Console.WriteLine("\nProjects added");
        }
    }
}
