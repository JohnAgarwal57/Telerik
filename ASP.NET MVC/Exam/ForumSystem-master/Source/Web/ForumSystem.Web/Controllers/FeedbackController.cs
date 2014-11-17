namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure;
    using ForumSystem.Web.ViewModels.Feedback;
    using Microsoft.AspNet.Identity;

    public class FeedbackController : Controller
    {
        private readonly IDeletableEntityRepository<Feedback> feedback;

        private readonly ISanitizer sanitizer;

        public FeedbackController(IDeletableEntityRepository<Feedback> feedback, ISanitizer sanitizer)
        {
            this.feedback = feedback;
            this.sanitizer = sanitizer;
        }

        [HttpGet]
        [OutputCache(Duration = 5 * 60)]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedbackViewModel feedbackModel)
        {
            if (this.ModelState.IsValid)
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    feedbackModel.AuthorId = this.User.Identity.GetUserId();
                }

                feedbackModel.Title = this.sanitizer.Sanitize(feedbackModel.Title);
                feedbackModel.Content = this.sanitizer.Sanitize(feedbackModel.Content);

                var feedback = new Feedback();
                Mapper.Map(feedbackModel, feedback, typeof(FeedbackViewModel), typeof(Feedback));

                this.feedback.Add(feedback);
                this.feedback.SaveChanges();
                feedbackModel = null;

                return this.RedirectToAction("Index", "Home", null);
            }
            else
            {
                return this.View(feedbackModel);
            }
        }
    }
}