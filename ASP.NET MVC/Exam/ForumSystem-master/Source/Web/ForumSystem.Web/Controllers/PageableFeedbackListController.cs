namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure;
    using ForumSystem.Web.ViewModels.Feedback;

    [Authorize(Users = "")]
    public class PageableFeedbackListController : Controller
    {
        private const int DefaultPageSize = 4;

        private readonly IDeletableEntityRepository<Feedback> feedbacks;
        private readonly ISanitizer sanitizer;

        public PageableFeedbackListController(IDeletableEntityRepository<Feedback> feedbacks, ISanitizer sanitizer)
        {
            this.feedbacks = feedbacks;
            this.sanitizer = sanitizer;
        }

        public ActionResult Index(int? id)
        {
            if (id == null || id == 0)
            {
                id = 1;
            }

            var result = this.feedbacks.All()
                             .OrderByDescending(c => c.Id)
                             .AsQueryable()
                             .Project()
                             .To<FeedbackViewModel>()
                             .ToList();

            this.ViewBag.PageNumber = (result.Count / DefaultPageSize) + 1;
            this.ViewBag.CurrentPage = id;

            result = result.Skip(((int)id - 1) * DefaultPageSize)
                           .Take(DefaultPageSize)
                           .ToList();

            return this.View(result);
        }
    }
}