namespace Northwind
{
    using System;
    using System.Linq;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();

            CustomerOperations.Insert(northwindEntities, "AAAAA", "Test");
            CustomerOperations.Update(northwindEntities, "AAAAA", "New Test");
            CustomerOperations.Delete(northwindEntities, "AAAAA");

            FindAllOrdersFrom1997ToCanada(northwindEntities);

            Console.WriteLine("--------------------------");
            FindAllOrdersFrom1997ToCanadaWithSQL(northwindEntities);
            Console.WriteLine("--------------------------");

            FindSales(northwindEntities, "BC", new DateTime(1996, 08, 01), new DateTime(1997, 08, 01));
        }

        private static void FindAllOrdersFrom1997ToCanada(NorthwindEntities northwindEntities)
        {
            var orders = northwindEntities.Customers
                .Join(northwindEntities.Orders, (c => c.CustomerID), (o => o.CustomerID), (c, o) =>
                    new
                    {
                        Company = c.CompanyName,
                        Date = o.ShippedDate,
                        Country = o.ShipCountry
                    })
                    .Where(c => c.Country == "Canada")
                    .Where(c => c.Date.Value.Year == 1997)
                    .Select(c => c.Company);

            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }

        private static void FindAllOrdersFrom1997ToCanadaWithSQL(NorthwindEntities northwindEntities)
        {
            string query = "SELECT c.CompanyName from Customers c inner join Orders o on c.CustomerID = o.CustomerID where o.ShipCountry = 'Canada' and YEAR(o.OrderDate) = 1997";


            var ContactNames = northwindEntities.Database.SqlQuery<string>(query).ToList();

            foreach (var name in ContactNames)
            {
                Console.WriteLine("{0}", name);
            }
            
        }

        private static void FindSales(NorthwindEntities northwindEntities, string region, DateTime startDate, DateTime endDate)
        {
            var orders = northwindEntities.Customers
                .Join(northwindEntities.Orders, (c => c.CustomerID), (o => o.CustomerID), (c, o) =>
                    new
                    {
                        Company = c.CompanyName,
                        Region = c.Region,
                        Date = o.ShippedDate
                    })
                    .Where(c => c.Region == region)
                    .Where(c => c.Date >= startDate)
                    .Where(c => c.Date <= endDate)
                    .Select(c => c.Company);

            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }
    }
}
