namespace EasyPTC.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using EasyPTC.Models;
    using EasyPTC.Web.Infrastructure.Mapping;

    public class PricingPlanViewModel : IMapFrom<PricingPlan>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Number of text ads clicks")]
        public int NumberOfTextAdsClicks { get; set; }

        [Display(Name = "Price for text ads clicks")]
        public decimal PriceForTextAdsClicks { get; set; }

        [Display(Name = "Number of banner clicks")]
        public int NumberOfBannerClicks { get; set; }

        [Display(Name = "Number for banner clicks")]
        public decimal PriceForBannerClicks { get; set; }
    }
}