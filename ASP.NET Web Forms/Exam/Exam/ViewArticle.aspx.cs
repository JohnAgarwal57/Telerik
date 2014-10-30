using NewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSite
{
    public partial class ViewArticle : System.Web.UI.Page
    {

        private ApplicationDbContext dbContext;

        public ViewArticle()
        {
            this.dbContext = new ApplicationDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public Article FormViewArticleDetails_GetItem([QueryString("id")]int? articleId)
        {
            if (articleId == null)
            {
                this.Response.Redirect("~/");
            }

            var article = this.dbContext.Articles.FirstOrDefault(a => a.Id == articleId);

            if (this.User.Identity.IsAuthenticated)
            {
                this.ShowLikeButtons(articleId);
            }
            
            return article;
        }

        private void ShowLikeButtons(int? articleId)
        {
            var likeValue = this.LoginViewMenu.FindControl("LabelLikeValue") as Label;
            var likeCount = this.dbContext.Articles.FirstOrDefault(a => a.Id == articleId).LikesPower.ToString();

            if (likeValue != null)
            {
                likeValue.Text = likeCount;
            }

            var currentUser = this.dbContext.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var currentLike = this.dbContext.Likes.FirstOrDefault(l => l.User.Id == currentUser.Id && l.ArticleId == articleId);

            if (currentLike != null)
            {
                if (currentLike.Value == 1)
                {
                    var upButton = this.LoginViewMenu.FindControl("LinkButtonVoteUp") as LinkButton;
                    upButton.Visible = false;
                    var downButton = this.LoginViewMenu.FindControl("LinkButtonVoteDown") as LinkButton;
                    downButton.Visible = true;
                }
                else if (currentLike.Value == -1)
                {
                    var upButton = this.LoginViewMenu.FindControl("LinkButtonVoteUp") as LinkButton;
                    upButton.Visible = true;
                    var downButton = this.LoginViewMenu.FindControl("LinkButtonVoteDown") as LinkButton;
                    downButton.Visible = false;
                }
                else
                {
                    var upButton = this.LoginViewMenu.FindControl("LinkButtonVoteUp") as LinkButton;
                    upButton.Visible = true;
                    var downButton = this.LoginViewMenu.FindControl("LinkButtonVoteDown") as LinkButton;
                    downButton.Visible = true;
                }
            }
        }

        protected void LinkButtonVoteUp_Click(object sender, EventArgs e)
        {
            var articleId = int.Parse(this.Request.QueryString["Id"]);
            var currentArticle = this.dbContext.Articles.FirstOrDefault(a => a.Id == articleId);
            var currentUser = this.dbContext.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var currentLike = this.dbContext.Likes.FirstOrDefault(l => l.User.Id == currentUser.Id && l.Article.Id == currentArticle.Id);

            if (currentLike != null)
            {
                currentLike.Value = 1;
                // +2 becouse if I'm in this case it means I already voted with -1 and now I'm changing to +1 , which is 2 difference
                currentArticle.LikesPower += 2;
            }
            else
            {
                var newLike = new Like
                {
                    Value = 1,
                    User = currentUser,
                    Article = currentArticle
                };

                currentArticle.LikesCount++;
                currentArticle.LikesPower += 1;
                this.dbContext.Likes.Add(newLike);
            }

            this.dbContext.SaveChanges();
            this.ShowLikeButtons(articleId);
        }

        protected void LinkButtonVoteDown_Click(object sender, EventArgs e)
        {
            var articleId = int.Parse(this.Request.QueryString["Id"]);
            var currentArticle = this.dbContext.Articles.FirstOrDefault(a => a.Id == articleId);
            var currentUser = this.dbContext.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);

            var currentLike = this.dbContext.Likes.FirstOrDefault(l => l.User.Id == currentUser.Id && l.Article.Id == currentArticle.Id);

            if (currentLike != null)
            {
                currentLike.Value = -1;
                // +2 becouse if I'm in this case it means I already voted with 1 and now I'm changing to -1 , which is 2 difference
                currentArticle.LikesPower -= 2;
            }
            else
            {
                var newLike = new Like
                {
                    Value = -1,
                    User = currentUser,
                    Article = currentArticle
                };

                currentArticle.LikesCount++;
                currentArticle.LikesPower -= 1;
                this.dbContext.Likes.Add(newLike);
            }

            this.dbContext.SaveChanges();
            this.ShowLikeButtons(articleId);
        }
    }
}