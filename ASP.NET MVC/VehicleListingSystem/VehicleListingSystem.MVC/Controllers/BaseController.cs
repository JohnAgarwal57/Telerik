namespace VehicleListingSystem.MVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using VehicleListingSystem.Web.Infrastructure;

    public class BaseController : Controller
    {
        public SessionState SessionState { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.SessionState = new SessionState();

            if (filterContext.HttpContext.Session != null && filterContext.HttpContext.Session["SessionState"] != null)
            {
                this.SessionState = filterContext.HttpContext.Session["SessionState"] as SessionState;
            }

            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Session != null)
            {
                filterContext.HttpContext.Session["SessionState"] = this.SessionState;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}