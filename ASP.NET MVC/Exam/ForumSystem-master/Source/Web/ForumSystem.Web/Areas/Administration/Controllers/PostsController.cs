namespace ForumSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Areas.Administration.Controllers.Base;
    using ForumSystem.Web.Areas.Administration.ViewModels;
    using ForumSystem.Web.Infrastructure;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;

    public class PostsController : AdminController
    {
        private readonly IDeletableEntityRepository<Post> posts;
        private readonly ISanitizer sanitizer;

        public PostsController(IDeletableEntityRepository<Post> posts, ISanitizer sanitizer)
        {
            this.posts = posts;
            this.sanitizer = sanitizer;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public JsonResult Read([DataSourceRequest]
                               DataSourceRequest request)
        {
            var result = this.posts.All().AsQueryable()
                             .Project()
                             .To<PostViewModel>();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([DataSourceRequest]
                                   DataSourceRequest request, PostViewModel postModel)
        {
            if (postModel != null && this.ModelState.IsValid)
            {
                var post = new Post();
                post.AuthorId = this.User.Identity.GetUserId();
                post.Content = this.sanitizer.Sanitize(postModel.Content);
                post.Title = this.sanitizer.Sanitize(postModel.Title);

                this.posts.Add(post);
                this.posts.SaveChanges();
            }

            return this.Json(new[] { postModel }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([DataSourceRequest]
                                   DataSourceRequest request, PostViewModel postModel)
        {
            if (postModel != null && this.ModelState.IsValid)
            {
                var post = this.posts.All().FirstOrDefault(h => h.Id == postModel.Id);

                post.Content = this.sanitizer.Sanitize(postModel.Content);
                post.Title = this.sanitizer.Sanitize(postModel.Title);

                this.posts.Update(post);
                this.posts.SaveChanges();
            }

            return this.Json(new[] { postModel }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Destroy([DataSourceRequest]
                                    DataSourceRequest request, PostViewModel postModel)
        {
            if (postModel != null)
            {
                var post = this.posts.All().FirstOrDefault(h => h.Id == postModel.Id);
                this.posts.Delete(post);
                this.posts.SaveChanges();
            }

            return this.Json(new[] { postModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}