namespace EasyPTC.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using EasyPTC.Data;
    using EasyPTC.Models;
    using EasyPTC.Web.ViewModels;

    public class AdvertisementsController : BaseController
    {
        public AdvertisementsController(IEasyPtcData data)
            : base(data)
        {
        }

        // GET: Advertisements
        public ActionResult Index()
        {
            var textAds = this.Data.Advertisements.All()
                              .Where(a => a.Type == AdType.TextAd && a.AvailableClicks > 0)
                              .AsQueryable()
                              .Project()
                              .To<AdViewModel>().ToList();

            return this.View(textAds);
        }

        public ActionResult Details(Advertisement ad)
        {
            return View(ad);
        }

        public ActionResult Click(int id)
        {
            var textAdd = this.Data.Advertisements.GetById(id);

            textAdd.AvailableClicks--;
            this.Data.Advertisements.Update(textAdd);
            this.Data.SaveChanges();

            return this.Json(textAdd.AvailableClicks);
        }

        public ActionResult Get(int id)
        {
            var banners = this.Data.Advertisements.All()
                  .Where(a => a.Type == AdType.Banner && a.AvailableClicks > 0)
                  .AsQueryable()
                  .Project()
                  .To<AdViewModel>().ToList();

            var rand = new Random();
            rand.Next(0, banners.Count - 1);
            var banner = banners[rand.Next(0, banners.Count - 1)];

            var data = new
            {
                url = banner.Url,
                id = banner.Id,
                target = banner.Target
            };

            return this.Json(data);
        }
    }
}