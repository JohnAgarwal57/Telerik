namespace EasyPTC.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using EasyPTC.Data;
    using EasyPTC.Models;
    using EasyPTC.Web.Infrastructure;

    public abstract class BaseController : Controller
    {
        public BaseController(IEasyPtcData data)
        {
            this.Data = data;
        }

        public SessionState SessionState { get; set; }

        protected IEasyPtcData Data { get; set; }

        protected User CurrentUser { get; set; }

        protected ActionResult RedirectToAction<TController>(Expression<Action<TController>> action) where TController : Controller
        {
            var actionBody = (MethodCallExpression)action.Body;
            var methodName = actionBody.Method.Name;

            var controllerName = typeof(TController).Name;
            controllerName = controllerName.Substring(0, controllerName.Length - "Controller".Length);

            return this.RedirectToAction(methodName, controllerName);
        }

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