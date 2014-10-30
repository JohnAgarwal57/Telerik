using NewsSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsSite
{
    public partial class Home : System.Web.UI.Page
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.context.Articles.FirstOrDefault();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Article> ListViewMostPopularArticles_GetData()
        {
            return this.context.Articles.OrderByDescending(a => a.LikesPower).Take(3);
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> ListViewCategories_GetData()
        {
            return this.context.Categories.OrderBy(c => c.Name);
        }
    }
}