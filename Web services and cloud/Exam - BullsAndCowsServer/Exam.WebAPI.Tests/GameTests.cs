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
    public class GameTests
    {
        [TestMethod]
        public void GetFirst10_WhenScoresInDb_ShouldReturnFirst10()
        {
            Game[] games = this.GenerateValidTestGames(12);
            
            var data = Mock.Create<IApplicationData>();

            Mock.Arrange(() => data.Games.All())
                .Returns(() => games.AsQueryable());

            var controller = new GamesController(data);
            this.SetupController(controller);

            var actionResult = controller.GetPublicGames();
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<GameModel>>().Result.Select(a => a.Id).ToList();

            var expected = 10;

            Assert.AreEqual(expected, actual.Count());
        }

        [TestMethod]
        public void GetOnly10_WhenScoresInDbAndPageIsFirst_ShouldReturnOnlyFirst10()
        {
            Game[] games = this.GenerateValidTestGames(12);
            
            var data = Mock.Create<IApplicationData>();

            Mock.Arrange(() => data.Games.All())
                .Returns(() => games.AsQueryable());

            var controller = new GamesController(data);
            this.SetupController(controller);

            // MY Paging start from 0 so First Page is number 0
            var actionResult = controller.GetPublicGames(0);
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<GameModel>>().Result.Select(a => a.Id).ToList();

            var expected = 10;

            Assert.AreEqual(expected, actual.Count());
        }

        [TestMethod]
        public void GetOnly2_WhenScoresInDbAndPageIsSecond_ShouldReturnNext10OrLess()
        {
            Game[] games = this.GenerateValidTestGames(12);
            
            var data = Mock.Create<IApplicationData>();

            Mock.Arrange(() => data.Games.All())
                .Returns(() => games.AsQueryable());

            var controller = new GamesController(data);
            this.SetupController(controller);

            // MY Paging start from 0 so Second Page is number 1
            var actionResult = controller.GetPublicGames(1);
            var response = actionResult.ExecuteAsync(CancellationToken.None).Result;
            var actual = response.Content.ReadAsAsync<IEnumerable<GameModel>>().Result.Select(a => a.Id).ToList();

            var expected = 2;

            Assert.AreEqual(expected, actual.Count());
        }

        private Game[] GenerateValidTestGames(int count)
        {
            Game[] games = new Game[count];

            for (int i = 0; i < count; i++)
            {
                var game = new Game
                {
                    Id = i,
                    Name = string.Format("TestGame{0}", i)
                };
                games[i] = game;
            }

            return games;
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
                        { "controller", "games" }
                    });
        }
    }
}
