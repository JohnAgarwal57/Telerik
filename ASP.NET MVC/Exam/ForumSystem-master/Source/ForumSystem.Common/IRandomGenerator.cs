namespace ForumSystem.Common
{
    using System;

    public interface IRandomGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int length);

        string GetRandomStringWithRandomLength(int min, int max);

        DateTime GetRandomDate();

        DateTime GetRandomTime();
    }
}