namespace Company.SampleDataGenerator.Interfaces
{
    using System;

    internal interface IRandomDataGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomStringWithRandomLength(int min, int max);

        DateTime GetRandomDate();

        DateTime GetRandomTime();
    }
}
