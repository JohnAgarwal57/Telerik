using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrowserTypeAndIp
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LiteralOutput.Text += "Browser  type: " + this.Request.Browser.Type + "<br/>";
            this.LiteralOutput.Text += "IP: " + this.Request.UserHostAddress + "<br/>";
        }
    }
}