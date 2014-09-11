namespace DateTimeService
{
    using System;

   public class ServiceDateTime : IServiceDateTime
    {
        public string GetDay(DateTime value)
        {
            var culture = new System.Globalization.CultureInfo("bg-BG");
            var day = culture.DateTimeFormat.GetDayName(value.DayOfWeek);

            return day;
        }
    }
}
