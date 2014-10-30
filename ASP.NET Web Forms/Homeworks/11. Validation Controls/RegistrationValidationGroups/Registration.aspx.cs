using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationValidation
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBoxRequired_ServerValidate(object source, ServerValidateEventArgs e)
        {
            e.IsValid = this.CheckBoxAccept.Checked;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                this.Page.Response.Redirect("Success.aspx");
            }
            
        }
    }
}