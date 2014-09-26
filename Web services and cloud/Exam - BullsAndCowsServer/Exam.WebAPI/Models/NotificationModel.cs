namespace Exam.WebAPI.Models
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Exam.Models;

    public class NotificationModel
    {
        public static Expression<Func<Notification, NotificationModel>> FromNotification
        {
            get
            {
                return n => new NotificationModel
                {
                    Id = n.Id,
                    Message = n.Message,
                    DateCreated = n.DateCreated,
                    State = n.State.ToString(),
                    Type = n.Type.ToString(),
                    GameId = n.GameId
                };
            }
        }

        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public string State { get; set; }

        public string Type { get; set; }

        public int GameId { get; set; }
    }
}