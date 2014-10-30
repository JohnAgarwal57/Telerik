namespace Continents.DataGenerator
{
    using System;

    public interface IRandomDataGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomStringWithRandomLength(int min, int max);

        DateTime GetRandomDate();

        DateTime GetRandomTime();
    }
}
