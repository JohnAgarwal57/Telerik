namespace Exam.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Exam.Models;
    using Exam.WebAPI.Models;

    public class NotificationsController : BaseController
    {
        private const int DefaultPageSize = 10;

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetNotifications(int page)
        {
            var currentUser = this.data.Users.All().FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var notifications = this.data.Notifications.All()
                                    .Where(n => n.UserId == currentUser.Id)
                                    .Select(NotificationModel.FromNotification)
                                    .OrderBy(n => n.DateCreated)
                                    .Skip(page * DefaultPageSize)
                                    .Take(DefaultPageSize);

            return this.Ok(notifications);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetNotifications()
        {
            var currentUser = this.data.Users.All().FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var notifications = this.data.Notifications.All()
                                    .Where(n => n.UserId == currentUser.Id)
                                    .Select(NotificationModel.FromNotification)
                                    .OrderBy(n => n.DateCreated)
                                    .Take(DefaultPageSize);
           
            return this.Ok(notifications);
        }

        [Route("api/notifications/next")]
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetNext()
        {
            var currentUser = this.data.Users.All().FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var notification = this.data.Notifications.All()
                                   .Where(n => n.UserId == currentUser.Id && n.State == State.Unread)
                                   .OrderBy(n => n.DateCreated)
                                   .Select(NotificationModel.FromNotification)
                                   .FirstOrDefault();
           
            return this.Ok(notification);
        }
    }
}