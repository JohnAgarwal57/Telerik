using System;
using System.Linq;
using NewsSite.Models;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Dynamic;

namespace NewsSite.Admin
{
    public partial class Articles : System.Web.UI.Page
    {
        private ApplicationDbContext dbContext;

        public Articles()
        {
            this.dbContext = new ApplicationDbContext();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Article> ListViewArticles_GetData()
        {
            return this.dbContext.Articles.OrderBy(c => c.Id);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewArticles_DeleteItem(int id)
        {
            Article item = this.dbContext.Articles.Find(id);
            this.dbContext.Articles.Remove(item);
            this.dbContext.SaveChanges();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewArticles_UpdateItem(int id)
        {
            Article item = this.dbContext.Articles.Find(id);
            if (item == null)
            {
                // The item wasn't found
                this.ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            this.TryUpdateModel(item);
            if (this.ModelState.IsValid)
            {
                this.dbContext.SaveChanges();
            }
        }

        public IQueryable<Category> DropDownListCategoriesCreate_GetData()
        {
            return this.dbContext.Categories.OrderBy(c => c.Name);
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
            this.btnWrapper.Visible = false;

            var fv = this.UpdatePanelInsertBook.FindControl("FormViewInsertArticle") as FormView;
            fv.Visible = true;
        }

        public void FormViewInsertArticle_InsertItem()
        {
            var item = new Article();
            TryUpdateModel(item);

            if (ModelState.IsValid)
            {
                var currentUser = this.dbContext.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
                item.DateCreated = DateTime.Now;
                item.Author = currentUser;
                this.dbContext.Articles.Add(item);
                this.dbContext.SaveChanges();
            }

            this.btnWrapper.Visible = true;

            var fv = this.UpdatePanelInsertBook.FindControl("FormViewInsertArticle") as FormView;
            fv.Visible = false;
        }
    }
}