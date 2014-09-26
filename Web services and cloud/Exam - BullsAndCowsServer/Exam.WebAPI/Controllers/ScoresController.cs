namespace Exam.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Exam.Data;
    using Exam.WebAPI.Models;

    public class ScoresController : BaseController
    {
        private const int TopUsers = 10;

        private readonly IApplicationData data;

        public ScoresController() : this(new ApplicationData())
        {
        }

        public ScoresController(IApplicationData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult GetScores()
        {
            var scores = this.data.Score.All().Select(ScoresModel.FromScore).OrderByDescending(s => s.Rank).ThenBy(s => s.UserName).Take(TopUsers);

            return this.Ok(scores);
        }
    }
}