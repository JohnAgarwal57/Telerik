namespace EasyPTC.Web.Areas.Administration.ViewModels.PrincingPlans
{
    using System;
    using System.Linq;
    using EasyPTC.Models;
    using EasyPTC.Web.Areas.Administration.ViewModels.Base;
    using EasyPTC.Web.Infrastructure.Mapping;
    using System.Web.Mvc;
    using System.ComponentModel.DataAnnotations;

    public class PricingPlanViewModel : AdministrationViewModel, IMapFrom<PricingPlan>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [UIHint("SingleLineTemplate")]
        public string Name { get; set; }

        [Display(Name = "Number of text ads clicks")]
        [UIHint("IntTemplate")]
        public int NumberOfTextAdsClicks { get; set; }

        [Display(Name = "Price for text ads clicks")]
        [UIHint("Currency")]
        public decimal PriceForTextAdsClicks { get; set; }

        [Display(Name = "Number of banner clicks")]
        [UIHint("IntTemplate")]
        public int NumberOfBannerClicks { get; set; }

        [Display(Name = "Number for banner clicks")]
        [UIHint("Currency")]
        public decimal PriceForBannerClicks { get; set; }
    }
}