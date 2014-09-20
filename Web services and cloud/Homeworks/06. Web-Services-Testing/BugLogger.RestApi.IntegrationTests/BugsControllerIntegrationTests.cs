namespace BugLogger.RestApi.IntegrationTests
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
    using System.Net;

    [TestClass]
    public class BugsControllerIntegrationTests
    {
        private static Random rand = new Random();
        private string inMemoryServerUrl = "http://localhost:12345";

        [TestMethod]
        public void GetAll_WhenBugsInDb_ShouldReturnStatus200AndNonEmptyContent()
        {
            IBugLoggerData data = Mock.Create<IBugLoggerData>();
            Bug[] bugs = { new Bug(), new Bug(), new Bug() };

            Mock.Arrange(() => data.Bugs.All())
                .Returns(() => bugs.AsQueryable());

            var server = new InMemoryHttpServer<Bug>(this.inMemoryServerUrl, data);

            var response = server.CreateGetRequest("/api/bugs");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsValid_ShouldReturn201AndLocationHeader()
        {
            IBugLoggerData data = Mock.Create<IBugLoggerData>();

            Bug bug = GetValidBug();

            Mock.Arrange(() => data.Bugs.Add(Arg.IsAny<Bug>()));

            var server = new InMemoryHttpServer<Bug>(this.inMemoryServerUrl, data);

            var response = server.CreatePostRequest("/api/bugs", bug);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Headers.Location);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsEmpty_ShouldReturn400()
        {
            IBugLoggerData data = Mock.Create<IBugLoggerData>();

            Bug bug = new Bug()
            {
                Text = ""
            };

            var server = new InMemoryHttpServer<Bug>(this.inMemoryServerUrl, data);

            var response = server.CreatePostRequest("/api/bugs", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostNewBug_WhenTextIsNull_ShouldReturn400()
        {
            IBugLoggerData data = Mock.Create<IBugLoggerData>();

            Bug bug = new Bug()
            {
                Text = null
            };

            var server = new InMemoryHttpServer<Bug>(this.inMemoryServerUrl, data);

            var response = server.CreatePostRequest("/api/bugs", bug);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }



        private Bug GetValidBug()
        {
            return new Bug()
            {
                Id = rand.Next(1000, 2000),
                Text = "New Bug #" + rand.Next(1000, 2000)
            };
        }
    }
}