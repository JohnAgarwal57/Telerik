namespace Cars.Operate
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Cars.Data;
    using Cars.Operate.Models;    
    using Cars.Models;
    using Newtonsoft.Json;

    internal class JsonImporter
    {
        public void Import(ICarsData data, string inputFolder)
        {
            Console.Write("Importing...");
            List<CarModel> cars = new List<CarModel>();

            data.AutoDetectChanges(false);

            foreach (string jsonFile in Directory.EnumerateFiles(inputFolder, "*.json"))
            {
                using (StreamReader r = new StreamReader(jsonFile))
                {
                    string json = r.ReadToEnd();
                    cars = JsonConvert.DeserializeObject<List<CarModel>>(json);
                    var index = 0;

                    foreach (var car in cars)
                    {
                        var manufacturer = GetManufacturer(data, car);
                        var city = GetCity(data, car);
                        var dealer = GetDealer(data, car);

                        var cityExistsInDealerCities = dealer.Cities.Any(c => c.Name == car.Dealer.City);
                        if (!cityExistsInDealerCities)
                        {
                            dealer.Cities.Add(city);                  
                        }

                        var newCar = new Car()
                        {
                            Manufacturer = manufacturer,
                            ManufacturerId = manufacturer.Id,
                            Dealer = dealer,
                            DealerId = dealer.Id,
                            Price = car.Price,
                            Model = car.Model,
                            TransmitionType = car.TransmissionType,
                            Year = car.Year
                        };

                        data.Cars.Add(newCar);

                        index++;
                        if (index % 200 == 0)
                        {
                            Console.Write(".");
                            data.SaveChanges();
                        } 
                    }
                }
            }
            
            Console.WriteLine("Done!");
            data.AutoDetectChanges(true);
        }

        private static Dealer GetDealer(ICarsData data, CarModel car)
        {
            var dealer = data.Dealers.Local().FirstOrDefault(d => d.Name == car.Dealer.Name);
            if (dealer == null)
            {
                dealer = new Dealer();
                dealer.Name = car.Dealer.Name;
                data.Dealers.Add(dealer);
            }

            return dealer;
        }

        private static City GetCity(ICarsData data, CarModel car)
        {
            var city = data.Cities.Local().FirstOrDefault(c => c.Name == car.Dealer.City);
            if (city == null)
            {
                city = new City();
                city.Name = car.Dealer.City;
                data.Cities.Add(city);
            }

            return city;
        }

        private static Manufacturer GetManufacturer(ICarsData data, CarModel car)
        {
            var manifacturer = data.Manufacturers.Local().FirstOrDefault(m => m.Name == car.ManufacturerName);
            if (manifacturer == null)
            {
                manifacturer = new Manufacturer();
                manifacturer.Name = car.ManufacturerName;
                data.Manufacturers.Add(manifacturer);
            }

            return manifacturer;
        }
    }
}