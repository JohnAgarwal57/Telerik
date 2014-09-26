namespace Exam.WebAPI.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Web.Http;
    using System.Web.Http.Routing;
    using Exam.Data;
    using Exam.Models;
    using Exam.WebAPI.Controllers;
    using Exam.WebAPI.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class ScoreTests
    {
        [TestMethod]
        public void GetAll_WhenScoresInDb_ShouldReturnScores()
        {
            Score[] scores = this.GenerateValidTestScores(5);
            
            var data = Mock.Create<IApplicationData>();

            Mock.Arrange(() => data.Score.All())
                .Returns(() => scores.AsQueryable());

            var controller = new ScoresController(data);
            this.SetupController(controller);

            var actionResult = controller.GetScores();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<ScoresModel>>().Result.Select(a => a.Rank).ToList();

            var expected = scores.AsQueryable().Select(a => a.Rank).ToList();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void GetOnly10_WhenScoresInDb_ShouldReturnTop10Scores()
        {
            Score[] scores = this.GenerateValidTestScores(12);
            
            var data = Mock.Create<IApplicationData>();

            Mock.Arrange(() => data.Score.All())
                .Returns(() => scores.AsQueryable());

            var controller = new ScoresController(data);
            this.SetupController(controller);

            var actionResult = controller.GetScores();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<ScoresModel>>().Result.Select(a => a.Rank).ToList();

            var expected = 10;

            Assert.AreEqual(expected, actual.Count());
        }

        [TestMethod]
        public void GetNoting_WheNothingInDb_ShouldReturn0Scores()
        {
            Score[] scores = new Score[0];
            
            var data = Mock.Create<IApplicationData>();

            Mock.Arrange(() => data.Score.All())
                .Returns(() => scores.AsQueryable());

            var controller = new ScoresController(data);
            this.SetupController(controller);

            var actionResult = controller.GetScores();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<ScoresModel>>().Result.Select(a => a.Rank).ToList();

            var expected = 0;

            Assert.AreEqual(expected, actual.Count());
        }

        private Score[] GenerateValidTestScores(int count)
        {
            Score[] scores = new Score[count];
            var rand = new Random();

            for (int i = 0; i < count; i++)
            {
                var score = new Score
                {
                    Id = i,
                    Rank = rand.Next(1000),
                    UserName = string.Format("{0}user@abv.bg", i)
                };
                scores[i] = score;
            }

            return scores;
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
                        { "controller", "scores" }
                    });
        }
    }
}