namespace BugLogger.Web.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using BugLogger.Models;

    public class BugModel
    {
        public static Expression<Func<Bug, BugModel>> FromBug
        {
            get
            {
                return a => new BugModel
                {
                    Id = a.Id,
                    Status = a.Status.ToString(),
                    Text = a.Text,
                    LogDate = a.LogDate
                };
            }
        }

        public int Id { get; set; }

        public string Status { get; set; }

        public string Text { get; set; }

        public DateTime? LogDate { get; set; }

        public override bool Equals(object obj)
        {
            var otherObj = obj as BugModel;

            if (this.Id == otherObj.Id
                && this.Status == otherObj.Status
                && this.Text == otherObj.Text
                && this.LogDate == otherObj.LogDate)
            {
                return true;
            }

            return false;
        }
    }
}