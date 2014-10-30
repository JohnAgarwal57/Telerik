namespace CookieLogin
{
    using System;
    using System.Linq;
    using System.Web;

    public partial class Main : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            HttpCookie cookie = this.Request.Cookies["UserName"];
            if (cookie == null)
            {
                this.Page.Response.Redirect("Login.aspx");
            }
        }
    }
}