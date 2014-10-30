namespace NewsSite.Admin
{
    using System;
    using System.Linq;
    using NewsSite.Models;
    using System.Web.UI.WebControls;

    public partial class Categories : System.Web.UI.Page
    {
        private ApplicationDbContext dbContext;

        public Categories()
        {
            this.dbContext = new ApplicationDbContext();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<NewsSite.Models.Category> ListViewCategories_GetData()
        {
            return this.dbContext.Categories.OrderBy(c => c.Name);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_DeleteItem(int id)
        {
            Category item = this.dbContext.Categories.Find(id);
            this.dbContext.Categories.Remove(item);
            this.dbContext.SaveChanges();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_UpdateItem(int id)
        {
            Category item = this.dbContext.Categories.Find(id);
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

        public void ListViewCategories_InsertItem()
        {
            var item = new Category();
            this.TryUpdateModel(item);

            var existing = this.dbContext.Categories.FirstOrDefault(c => c.Name == item.Name);
            if (existing == null)
	        {
                if (this.ModelState.IsValid)
                {
                    this.dbContext.Categories.Add(item);
                    this.dbContext.SaveChanges();
                }
	        }
        }
    }
}