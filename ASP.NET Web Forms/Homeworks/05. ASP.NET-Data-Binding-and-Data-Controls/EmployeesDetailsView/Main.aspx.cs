namespace EmployeesDetailsView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Northwind;


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

            this.GridViewEmployees.DataSource = employees;
            this.GridViewEmployees.DataBind();
        }
    }
}