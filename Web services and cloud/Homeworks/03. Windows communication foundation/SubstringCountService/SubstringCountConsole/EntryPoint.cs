namespace SubstringCountConsole
{
    using System;

    public class EntryPoint
    {
        private static void Main()
        {
            string word = "alabalanica";
            string substring = "ala";
            ServiceSubstringCountClient substringClient = new ServiceSubstringCountClient();
            int count = substringClient.Count(word, substring);

            Console.WriteLine("You can find the substring {1} in {0} {2} times ", word, substring, count);
        }
    }
}
