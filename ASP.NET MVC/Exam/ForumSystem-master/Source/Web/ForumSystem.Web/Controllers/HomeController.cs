namespace ForumSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.ViewModels.Home;
    using Microsoft.AspNet.Identity;

    public class HomeController : Controller
    {
        private readonly IDeletableEntityRepository<Post> posts;
        private readonly IDeletableEntityRepository<Vote> votes;

        public HomeController(IDeletableEntityRepository<Post> posts, IDeletableEntityRepository<Vote> votes)
        {
            this.posts = posts;
            this.votes = votes;
        }

        public ActionResult Index()
        {
            var model = this.posts.All().Project().To<IndexBlogPostViewModel>();
            return this.View(model);
        }

        public ActionResult Vote(int voteScore, int postId, IndexBlogPostViewModel model)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var vote = this.votes.All().FirstOrDefault(v => v.UserId == currentUserId && v.PostId == postId);

            if (vote == null)
            {
                var newVote = new Vote
                {
                    UserId = currentUserId,
                    PostId = postId,
                    Value = voteScore
                };

                this.votes.Add(newVote);
                this.votes.SaveChanges();
 
                var post = this.posts.GetById(postId);
                post.VoteScore += voteScore;
                this.posts.Update(post);
                voteScore = post.VoteScore;

                this.posts.SaveChanges();
            }

            return this.Json(voteScore);
        }
    }
}