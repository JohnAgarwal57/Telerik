namespace ForumSystem.Web.Areas.Administration.Controllers.Base
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    [Authorize(Users = "")]
    public class AdminController : Controller
    {
        public AdminController()
            : base()
        {
        }
    }
}