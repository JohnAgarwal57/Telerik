namespace VehicleListingSystem.MVC.ViewModels
{
    using System.Web.Mvc;

    public class VehicleViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Manifacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
    }
}