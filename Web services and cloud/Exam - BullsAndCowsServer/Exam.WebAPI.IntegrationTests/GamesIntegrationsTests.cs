namespace Exam.WebAPI.IntegrationTests
{
    using System;
    using System.Linq;
    using System.Net;
    using Exam.Data;
    using Exam.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    [TestClass]
    public class GamesIntegrationsTests
    {
        private readonly string inMemoryServerUrl = "http://localhost:12345";

        [TestMethod]
        public void TestIfUserCanGetViewUnstartedGames()
        {
            IApplicationData data = Mock.Create<IApplicationData>();
            Game[] games = { new Game(), new Game(), new Game() };

            Mock.Arrange(() => data.Games.All())
                .Returns(() => games.AsQueryable());

            var server = new InMemoryHttpServer<Game>(this.inMemoryServerUrl, data);

            var response = server.CreateGetRequest("/api/games");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
    }
}