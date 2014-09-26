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
    public class ScoreIntegrationTests
    {
        private readonly string inMemoryServerUrl = "http://localhost:12345";

        [TestMethod]
        public void TestIfUserCanGetHighScores()
        {
            IApplicationData data = Mock.Create<IApplicationData>();
            Score[] scores = { new Score(), new Score(), new Score() };

            Mock.Arrange(() => data.Score.All())
                .Returns(() => scores.AsQueryable());

            var server = new InMemoryHttpServer<Score>(this.inMemoryServerUrl, data);

            var response = server.CreateGetRequest("/api/scores");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
    }
}