namespace EasyPTC.Web.Areas.Administration.ViewModels.Advertisements
{
    using EasyPTC.Models;
    using EasyPTC.Web.Areas.Administration.ViewModels.Base;
    using EasyPTC.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class AdvertisementViewModel : AdministrationViewModel, IMapFrom<Advertisement>
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Display(Name = "Име")]
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [UIHint("SingleLineTemplate")]
        public string Name { get; set; }

        [Display(Name = "Photo")]
        [Required]
        [StringLength(100, MinimumLength = 5)]
        [UIHint("SingleLineTemplate")]
        public string Url { get; set; }

        [Required]
        [Display(Name = "Останали кликове")]
        [Range(0, 1000)]
        [UIHint("IntTemplate")]
        public int AvailableClicks { get; set; }

        [UIHint("EnumTemplate")]
        public AdType Type { get; set; }

        [Display(Name = "URL")]
        [UIHint("SingleLineTemplate")]
        public string Target { get; set; }
    }
}