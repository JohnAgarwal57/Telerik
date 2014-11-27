namespace VehicleListingSystem.MVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using VehicleListingSystem.Data;
    using VehicleListingSystem.MVC.Infrastructure;
    using VehicleListingSystem.MVC.ViewModels;

    public class HomeController : BaseController
    {
        private const string FileLocation = "~/App_Data/VehicleList.xml";
        private readonly List<VehicleViewModel> vehicles;
        private readonly IXmlParser parser = new XmlParser();

        public HomeController()
        {
            Mapper.CreateMap<Vehicle, VehicleViewModel>();

            this.vehicles = this.parser.Parse(FileLocation)
                                .AsQueryable()
                                .Project()
                                .To<VehicleViewModel>()
                                .ToList();
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public JsonResult GetVehicles()
        {
            return this.Json(this.vehicles, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetModel(int id)
        {
            var vehicleModel = this.vehicles.FirstOrDefault(v => v.Id == id);
            this.SessionState.VehicleViewModel = vehicleModel;
            return this.Json(vehicleModel);
        }

        [HttpPost]
        public ActionResult LoadDetailsPartial()
        {
            return this.PartialView("_Details", this.SessionState.VehicleViewModel);
        }
    }
}