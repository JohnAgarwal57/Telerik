namespace Company.SampleDataGenerator.DataGenerators
{
    using Company.Data;
    using Interfaces;

    internal abstract class DataGenerator : IDataGenerator
    {
        private IRandomDataGenerator random;
        private CompanyEntities db;
        private int count;

        public DataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyeEntities, int countOfGeneratedObjects)
        {
            this.random = randomDataGenerator;
            this.db = companyeEntities;
            this.count = countOfGeneratedObjects;
        }

        protected IRandomDataGenerator Random
        {
            get { return this.random; }
        }

        protected CompanyEntities Database
        {
            get { return this.db; }
        }

        protected int Count
        {
            get { return this.count; }
        }

        public abstract void Generate();
    }
}
