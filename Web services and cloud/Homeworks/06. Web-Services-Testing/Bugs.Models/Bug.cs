namespace BugLogger.Models
{
    using System;

    public class Bug
    {
        public int Id { get; set; }

        public Status Status { get; set; }

        public string Text { get; set; }

        public DateTime LogDate { get; set; }
    }
}
