namespace Cars.Operate.Models
{
    using Cars.Models;

    public class CarModel
    {
        public int Year { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public DealerModel Dealer { get; set; }
    }
}