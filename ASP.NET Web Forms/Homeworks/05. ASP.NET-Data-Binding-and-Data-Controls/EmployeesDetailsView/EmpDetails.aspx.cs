namespace EmployeesDetailsView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Northwind;

    public partial class EmpDetails : System.Web.UI.Page
    {
        private northwindEntities content = new northwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Request.Params["Id"] == null)
            {
                this.Response.Redirect("Main.aspx");
            }

            var id = int.Parse(this.Request.Params["id"]);

            var employee = this.content.Employees.Where(em => em.EmployeeID == id).ToList(); ;
            this.DetailsViewEmployee.DataSource = employee;
            this.DataBind();
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Main.aspx");
        }
    }
}