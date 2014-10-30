namespace Continents.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Continents.Models;
    using Continents.DataGenerator;

    internal sealed class Configuration : DbMigrationsConfiguration<Continents.Data.ContinentsDbContext>
    {
        private IRandomDataGenerator random = RandomDataGenerator.Instance;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ContinentsDbContext context)
        {
            var existingContinents = context.Continents.FirstOrDefault();

            if (existingContinents == null)
            {
                this.SeedLanguages(context, 20);
                this.SeedContinents(context);
                this.SeedCountries(context, 200);
                this.SeedTowns(context, 2000);
            }
        }

        private void SeedLanguages(ContinentsDbContext context, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var language = new Language
                {
                    Name = this.random.GetRandomStringWithRandomLength(5, 15)
                };

                context.Languages.Add(language);
            }

            context.SaveChanges();
        }

        private void SeedContinents(ContinentsDbContext context)
        {
            var continents = new[] { "Europe", "Africa", "Asia", "South America", "North America", "Australia", "Antartica" };

            for (int i = 0; i < continents.Length; i++)
            {
                var continent = new Continent
                {
                    Name = continents[i]
                };

                context.Continents.Add(continent);
            }

            context.SaveChanges();
        }

        private void SeedCountries(ContinentsDbContext context, int count)
        {
            var languagesCount = context.Languages.Count();

            for (int i = 0; i < count; i++)
            {
                var country = new Country
                {
                    Name = this.random.GetRandomStringWithRandomLength(5, 15),
                    Population = this.random.GetRandomNumber(100000, 100000000),
                    LanguageId = this.random.GetRandomNumber(1, languagesCount),
                    ContinentId = this.random.GetRandomNumber(1, 7),
                };

                context.Countries.Add(country);
            }

            context.SaveChanges();
        }

        private void SeedTowns(ContinentsDbContext context, int count)
        {
            var countriesCount = context.Countries.Count();

            for (int i = 0; i < count; i++)
            {
                var town = new Town
                {
                    Name = this.random.GetRandomStringWithRandomLength(5, 15),
                    Population = this.random.GetRandomNumber(100000, 100000000),
                    CountryId = this.random.GetRandomNumber(1, countriesCount),
                };

                context.Towns.Add(town);
            }

            context.SaveChanges();
        }
    }
}
