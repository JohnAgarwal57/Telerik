namespace DateTimeConsole
{  
    using System;
    using DateTimeConsole.ServiceDateTime;

    public class EntryPoint
    {
        private static void Main()
        {
            ServiceDateTimeClient dateTimeClient = new ServiceDateTimeClient();
            string day = dateTimeClient.GetDay(DateTime.Now);
            Console.WriteLine("Днес е {0}!", day);
        }
    }
}
