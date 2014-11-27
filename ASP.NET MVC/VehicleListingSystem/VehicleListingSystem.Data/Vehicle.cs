namespace VehicleListingSystem.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Manifacturer { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Image { get; set; }
    }
}