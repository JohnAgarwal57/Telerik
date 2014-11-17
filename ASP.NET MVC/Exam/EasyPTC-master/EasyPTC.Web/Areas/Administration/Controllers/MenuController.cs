namespace EasyPTC.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using EasyPTC.Data;
    using EasyPTC.Models;
    using EasyPTC.Web.Areas.Administration.Controllers.Base;

    public class MenuController : AdminController
    {
        public MenuController(IEasyPtcData data) : base(data)
        {
        }

        // GET: Administration/Menu
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Advertisments()
        {
            var types = Enum.GetValues(typeof(AdType)).Cast<AdType>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            });

            this.ViewBag.Types = types;

            return this.View();
        }

        public ActionResult PricingPlans()
        {
            return this.View();
        }
    }
}