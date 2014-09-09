namespace Cars.Operate
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Cars.Data;

    internal class XmlSearcher
    {
        private readonly string reportFolder = string.Format("{0}{1}", Directory.GetCurrentDirectory(), @"\Reports\");

        public void Search(ICarsData data, string path)
        {
            var xmlQueries = XElement.Load(path).Elements();

            foreach (var xmlQuery in xmlQueries)
            {
                var allCars = data.Cars.All();

                var whereClauses = xmlQuery.Element("WhereClauses").Elements();
                var saveName = xmlQuery.Attribute("OutputFileName").Value;
                var xmlResultSet = new XElement("Cars");

                foreach (var clause in whereClauses)
                {
                    var propertyName = clause.Attribute("PropertyName").Value;
                    var type = clause.Attribute("Type").Value;

                    allCars = Where(data, allCars, clause, propertyName, type);
                }

                var orderBy = xmlQuery.Element("OrderBy").Value;
                allCars = OrderBy(allCars, orderBy);

                var result = allCars.ToList();

                foreach (var itemInResult in result)
                {
                    var car = GenerateXmlElement(data, itemInResult);
                    xmlResultSet.Add(car);
                }

                if (!Directory.Exists(this.reportFolder))
                {
                    Directory.CreateDirectory(this.reportFolder);
                }

                xmlResultSet.Save(string.Format("{0}{1}", this.reportFolder, saveName));
                Console.WriteLine(string.Format("{0} report made", saveName));
            }
        }

        private static XElement GenerateXmlElement(ICarsData data, Cars.Models.Car itemInResult)
        {
            var car = new XElement("Car");

            car.Add(new XElement("TransmissionType", itemInResult.TransmitionType));

            var dealer = data.Dealers.All().First(d => d.Id == itemInResult.DealerId);

            var xmlDealer = new XElement("Dealer", dealer.Name);

            var cities = itemInResult.Dealer.Cities.ToList();

            string listOfCities = string.Empty;

            foreach (var city in cities)
            {
                listOfCities += string.Format("{0}, ", city.Name);
            }

            xmlDealer.Add(new XElement("Cities", listOfCities.TrimEnd(' ').TrimEnd(',')));
            car.Add(xmlDealer);

            car.SetAttributeValue("Manufacturer", itemInResult.Manufacturer.Name);
            car.SetAttributeValue("Model", itemInResult.Model);
            car.SetAttributeValue("Year", itemInResult.Year);
            car.SetAttributeValue("Price", itemInResult.Price);

            return car;
        }

        private static IQueryable<Cars.Models.Car> OrderBy(IQueryable<Cars.Models.Car> allCars, string orderBy)
        {
            if (orderBy == "Id")
            {
                allCars = allCars.OrderBy(c => c.Id);
            }

            if (orderBy == "Year")
            {
                allCars = allCars.OrderBy(c => c.Year);
            }

            if (orderBy == "Model")
            {
                allCars = allCars.OrderBy(c => c.Model);
            }

            if (orderBy == "Price")
            {
                allCars = allCars.OrderBy(c => c.Price);
            }

            if (orderBy == "Manufacturer")
            {
                allCars = allCars.OrderBy(c => c.Manufacturer.Name);
            }

            if (orderBy == "Dealer")
            {
                allCars = allCars.OrderBy(c => c.Dealer.Name);
            }

            return allCars;
        }

        private static IQueryable<Cars.Models.Car> Where(ICarsData data, IQueryable<Cars.Models.Car> allCars, XElement clause, string propertyName, string type)
        {
            if (propertyName == "City")
            {
                allCars = allCars.Where(c => c.Dealer.Cities.Any(city => city.Name == clause.Value));
            }

            if (propertyName == "Id")
            {
                var id = int.Parse(clause.Value);
                if (type == "GreaterThan")
                {
                    allCars = allCars.Where(c => c.Id > id);
                }

                if (type == "LessThan")
                {
                    allCars = allCars.Where(c => c.Id < id);
                }

                if (type == "Equals")
                {
                    allCars = allCars.Where(c => c.Id == id);
                }
            }

            if (propertyName == "Year")
            {
                var year = int.Parse(clause.Value);
                if (type == "GreaterThan")
                {
                    allCars = allCars.Where(c => c.Year > year);
                }

                if (type == "LessThan")
                {
                    allCars = allCars.Where(c => c.Year < year);
                }

                if (type == "Equals")
                {
                    allCars = allCars.Where(c => c.Year == year);
                }
            }

            if (propertyName == "Price")
            {
                var price = decimal.Parse(clause.Value, CultureInfo.InvariantCulture);
                if (type == "GreaterThan")
                {
                    allCars = allCars.Where(c => c.Price > price);
                }

                if (type == "LessThan")
                {
                    allCars = allCars.Where(c => c.Price < price);
                }

                if (type == "Equals")
                {
                    allCars = allCars.Where(c => c.Price == price);
                }
            }

            if (propertyName == "Model")
            {
                if (type == "Contains")
                {
                    allCars = allCars.Where(c => c.Model.Contains(clause.Value));
                }

                if (type == "Equals")
                {
                    allCars = allCars.Where(c => c.Model == clause.Value);
                }
            }

            if (propertyName == "Manufacturer ")
            {
                if (type == "Contains")
                {
                    allCars = allCars.Where(c => c.Manufacturer.Name.Contains(clause.Value));
                }

                if (type == "Equals")
                {
                    allCars = allCars.Where(c => c.Manufacturer.Name == clause.Value);
                }
            }

            if (propertyName == "Dealer ")
            {
                if (type == "Contains")
                {
                    allCars = allCars.Where(c => c.Dealer.Name.Contains(clause.Value));
                }

                if (type == "Equals")
                {
                    allCars = allCars.Where(c => c.Dealer.Name == clause.Value);
                }
            }

            return allCars;
        }
    }
}