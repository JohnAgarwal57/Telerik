namespace Continents.DataGenerator
{
    using System;

    public class RandomDataGenerator : IRandomDataGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static IRandomDataGenerator randomGenerator;
        private Random random;

        private RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static IRandomDataGenerator Instance
        {
            get
            {
                if (randomGenerator == null)
                {
                    randomGenerator = new RandomDataGenerator();
                }

                return randomGenerator;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(result);
        }

        public string GetRandomStringWithRandomLength(int min, int max)
        {
            return this.GetRandomString(this.GetRandomNumber(min, max));
        }

        public DateTime GetRandomDate()
        {
            DateTime start = new DateTime(1995, 1, 1);

            int range = (DateTime.Today - start).Days;
            return start.AddDays(this.random.Next(range));
        }

        public DateTime GetRandomTime()
        {
            DateTime start = this.GetRandomDate().AddHours(7);
            DateTime value = start.AddMinutes(this.random.Next(this.GetRandomNumber(0, 241)));

            return value;
        }
    }
}
