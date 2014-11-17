namespace EasyPTC.Web.ViewModels
{
    using EasyPTC.Models;
    using EasyPTC.Web.Infrastructure.Mapping;
    using System.Web.Mvc;

    public class AdViewModel : IMapFrom<Advertisement>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int AvailableClicks { get; set; }

        public string Target { get; set; }
    }
}