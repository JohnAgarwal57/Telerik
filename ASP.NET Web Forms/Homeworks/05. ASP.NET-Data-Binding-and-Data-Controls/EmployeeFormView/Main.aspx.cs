namespace EmployeeFormView
{
    using Northwind;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Main : System.Web.UI.Page
    {
        private northwindEntities content = new northwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                return;
            }

            var employees = this.content.Employees.AsQueryable().ToArray();

            this.FormViewEmployees.DataSource = employees;
            this.FormViewEmployees.DataBind();
        }

        protected void FormViewEmployees_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            var employees = this.content.Employees.AsQueryable().ToArray();

            this.FormViewEmployees.PageIndex = e.NewPageIndex;
            this.FormViewEmployees.DataSource = employees;
            this.FormViewEmployees.DataBind();
        }
    }
}