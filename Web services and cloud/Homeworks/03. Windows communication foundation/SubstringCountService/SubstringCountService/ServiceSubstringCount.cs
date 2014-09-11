namespace SubstringCountService
{
    class ServiceSubstringCount : IServiceSubstringCount
    {
        public int Count(string firstString, string substring)
        {
            int count = 0;
            int index = firstString.IndexOf(substring);

            while (index != -1)
            {
                count++;
                index = firstString.IndexOf(substring, index + 1);               
            }

            return count;
        }
    }
}
