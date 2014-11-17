namespace EasyPTC.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;
    using EasyPTC.Data;
    using EasyPTC.Web.Areas.Administration.Controllers.Base;
    using Kendo.Mvc.UI;
    using Model = EasyPTC.Models.PricingPlan;
    using ViewModel = EasyPTC.Web.Areas.Administration.ViewModels.PrincingPlans.PricingPlanViewModel;
    using System.Globalization;

    public class PricingPlansController : KendoGridAdministrationController
    {
        public PricingPlansController(IEasyPtcData data)
            : base(data)
        {
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]
                                   DataSourceRequest request, ViewModel model)
        {
            model.CreatedOn = DateTime.Now;
            var dbModel = base.Create<Model>(model);
            if (dbModel != null)
            {
                model.Id = dbModel.Id;
            }
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]
                                    DataSourceRequest request, ViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Data.PricingPlans.Delete(model.Id);
                this.Data.SaveChanges();
            }

            return this.GridOperation(model, request);
        }

        protected override IEnumerable GetData()
        {
            return this.Data.PricingPlans.All();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.PricingPlans.GetById(id) as T;
        }
    }
}