namespace BugLogger.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using BugLogger.Data;
    using BugLogger.Web.Models;
    using BugLogger.Models;
    

    public class BugsController : ApiController
    {
        private IBugLoggerData data;

        public BugsController()
            : this(new BugLogerData())
        {
        }

        public BugsController(IBugLoggerData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get(int id)
        {
            var bugs = this.data.Bugs.All()
                .Where(b => b.Id == id)
                .Select(BugModel.FromBug);

            return Ok(bugs);
        }

        public IHttpActionResult Get(string date)
        {
            DateTime searchedDate;
            if (!DateTime.TryParse(date, out searchedDate))
            {
                return this.BadRequest("Date isn't in valid format! Please us YYYY-MM-DD");
            }

            var bugs = this.data.Bugs.All()
                .Where(b => b.LogDate.Day == searchedDate.Day
                        && b.LogDate.Month == searchedDate.Month
                        && b.LogDate.Year == searchedDate.Year)
                .Select(BugModel.FromBug);

            return this.Ok(bugs);
        }

        public IHttpActionResult GetAllByStatus(string type)
        {
            Status status;
            if (!Enum.TryParse(type, true, out status))
            {
                return this.BadRequest("No such status type in the DB");
            }

            var bugs = this.data.Bugs.All()
                .Where(b => b.Status == status)
                .Select(BugModel.FromBug);

            return this.Ok(bugs);
        }

        public IHttpActionResult Get()
        {
            var bugs = this.data.Bugs.All()
                .Select(BugModel.FromBug);

            return this.Ok(bugs);
        }

        public IHttpActionResult PostBug(BugModel bug)
        {
            if (string.IsNullOrEmpty(bug.Text))
            {
                var ex = new ArgumentException();
                return this.BadRequest(ex.Message);
            }

            var newBug = new Bug
            {
                LogDate = DateTime.Now,
                Status = Status.Pending,
                Text = bug.Text
            };

            this.data.Bugs.Add(newBug);
            this.data.SaveChanges();

            var location = new Uri(this.Url.Link("DefaultApi", new { id = newBug.Id }));
            var response = this.Created(location, newBug);
            return response;
        }

        [HttpPut]
        public IHttpActionResult ChangeStatus(int id)
        {
            var existingBug = this.data.Bugs.All()
                .Where(b => b.Id == id)
                .FirstOrDefault();

            existingBug.Status = Status.Assigned;
            this.data.SaveChanges();

            var response = this.Ok();
            return response;
        }
    }
}
