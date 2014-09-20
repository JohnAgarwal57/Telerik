namespace BugLogger.RestApi.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using BugLogger.Data;
    using BugLogger.Models;
    using BugLogger.Web.Controllers;
    using BugLogger.Web.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class BugsControllerTests
    {
        [TestMethod]
        public void GetAll_WhenValid_ShouldReturnBugsCollection()
        {
            Bug[] bugs =
            {
                new Bug() { Text = "First bug" },
                new Bug() { Text = "Second bug" }
            };

            var data = Mock.Create<IBugLoggerData>();

            Mock.Arrange(() => data.Bugs.All())
                .Returns(() => bugs.AsQueryable());

            var controller = new BugsController(data);
            this.SetupController(controller);

            var actionResult = controller.Get();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<BugModel>>().Result.Select(a => a.Id).ToList();

            var expected = bugs.AsQueryable().Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetById_WhenValid_ShouldReturnTheObjectWithSearchedId()
        {
            var data = Mock.Create<IBugLoggerData>();

            Bug[] bugs =
            {
                new Bug()
                {
                    Id = 5,
                    Text = "First bug"
                }
            };

            Mock.Arrange(() => data.Bugs.All())
                .Returns(() => bugs.AsQueryable());

            var controller = new BugsController(data);
            this.SetupController(controller);

            var actionResult = controller.Get(5);
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<BugModel>>().Result.Select(a => a.Id).ToList();

            var expected = bugs.AsQueryable().Where(b => b.Id == 5).Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetByStatus_WhenValid_ShouldReturnCollectionMemberWithCorrespondingStatus()
        {
            Bug[] bugs =
            {
                new Bug()
                {
                    Text = "First bug",
                    Status = Status.Assigned
                },
                new Bug()
                {
                    Text = "Second bug",
                    Status = Status.Pending
                }
            };

            var data = Mock.Create<IBugLoggerData>();

            Mock.Arrange(() => data.Bugs.All())
                .Returns(() => bugs.AsQueryable());

            var controller = new BugsController(data);
            this.SetupController(controller);

            var actionResult = controller.GetAllByStatus("Pending");
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<BugModel>>().Result.Select(a => a.Id).ToList();

            var expected = bugs.AsQueryable().Where(b => b.Status == Status.Pending).Select(a => a.Id).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetByDate_WhenValid_ShouldReturnCollectionMemberWithCorrespondingStatus()
        {
            Bug[] bugs =
            {
                new Bug()
                {
                    Text = "First bug",
                    LogDate = DateTime.Now
                },
                new Bug()
                {
                    Text = "Second bug",
                    LogDate = DateTime.Now.AddDays(2)
                }
            };

            var data = Mock.Create<IBugLoggerData>();

            Mock.Arrange(() => data.Bugs.All())
                .Returns(() => bugs.AsQueryable());

            var controller = new BugsController(data);
            this.SetupController(controller);

            var actionResult = controller.Get(DateTime.Now.ToString());
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<BugModel>>().Result.Select(b => b.LogDate).ToList();

            var expected = bugs.AsQueryable()
                               .Where(b => b.LogDate.Day == DateTime.Now.Day &&
                                           b.LogDate.Month == DateTime.Now.Month &&
                                           b.LogDate.Year == DateTime.Now.Year)
                               .Select(b => b.LogDate)
                               .ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void AddBug_WhenBugTextIsValid_ShouldBeAddedToRepoWithLogDateAndStatusPending()
        {
            var bugs = new List<Bug>();

            var bug = new BugModel()
            {
                Text = "NEW TEST BUG"
            };

            var data = Mock.Create<IBugLoggerData>();

            Mock.Arrange(() => data.Bugs.All())
                .Returns(() => bugs.AsQueryable());

            Mock.Arrange(() => data.SaveChanges())
                .DoInstead(() => bugs.Add(new Bug() { Text = "NEW TEST BUG" }));

            var controller = new BugsController(data);
            this.SetupController(controller);

            //act
            controller.PostBug(bug);

            //assert
            Assert.AreEqual(data.Bugs.All().Count(), 1);
            var bugInDb = data.Bugs.All().FirstOrDefault();
            Assert.AreEqual(bug.Text, bugInDb.Text);
            Assert.IsNotNull(bugInDb.LogDate);
            Assert.AreEqual(Status.Pending, bugInDb.Status);
        }

        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "bugs" }
                    });
        }
    }
}