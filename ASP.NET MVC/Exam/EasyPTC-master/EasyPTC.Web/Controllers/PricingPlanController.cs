namespace EasyPTC.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using EasyPTC.Data;
    using EasyPTC.Web.ViewModels;
    using Microsoft.AspNet.Identity;

    [Authorize(Users = "")]
    public class PricingPlanController : BaseController
    {
        public PricingPlanController(IEasyPtcData data) : base(data)
        {
        }

        // GET: PrincingPlan
        public ActionResult Index()
        {
            var pricingPlans = this.Data.PricingPlans.All()
                                   .AsQueryable()
                                   .Project()
                                   .To<PricingPlanViewModel>().ToList();
            return this.View(pricingPlans);
        }

        public ActionResult AddToCart(int id)
        {
            var pricingPlan = this.Data.PricingPlans.GetById(id);
            this.SessionState.PricingPlans.Add(pricingPlan);
            return null;
        }

        public ActionResult Cart()
        {
            var pricingPlans = this.SessionState.PricingPlans;
            return this.View(pricingPlans);
        }

        public ActionResult RemoveFromCart(int id)
        {
            var pricingPlan = this.Data.PricingPlans.GetById(id);
            this.SessionState.PricingPlans.Remove(pricingPlan);
            return null;
        }

        public ActionResult Buy()
        {
            var pricingPlans = this.SessionState.PricingPlans;
            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.Data.Users.GetById(currentUserId);

            foreach (var item in pricingPlans)
            {
                item.Users.Add(currentUser);
                this.Data.SaveChanges();
            }

            return this.RedirectToAction("Index", "Home", null);
        }
    }
}