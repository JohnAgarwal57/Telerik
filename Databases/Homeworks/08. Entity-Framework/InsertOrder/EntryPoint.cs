namespace InsertOrder
{
    using System;
    using Northwind;

    class EntryPoint
    {
        private static NorthwindEntities northwindEntities = new NorthwindEntities();

        static void Main()
        {
            InsertOrder("ALFKI", DateTime.Now, "Sofia");          
        }

        static void InsertOrder(string customerID, DateTime orderDate, string address)
        {
            Order newOrder = new Order()
            {
                CustomerID = customerID,
                OrderDate = orderDate,
                ShipAddress = address
            };

            northwindEntities.Orders.Add(newOrder);

            northwindEntities.SaveChanges();
        }
    }
}
