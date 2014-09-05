namespace NorthwindTests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Northwind;
    using Telerik.JustMock;

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void InsertShouldInsertNewRecord()
        {
            var northwindEntities = new NorthwindEntities();
            var customerId = "AAAAA";

            CustomerOperations.Insert(northwindEntities, customerId, "Test company");

            var customer = CustomerOperations.FindById(northwindEntities, customerId);

            CustomerOperations.Delete(northwindEntities, customerId);

            Assert.AreEqual(customer.CustomerID, customerId);
        }

        [TestMethod]
        public void UpdateShouldChangeTheData()
        {
            var northwindEntities = new NorthwindEntities();
            var customerId = "AAAAA";

            CustomerOperations.Insert(northwindEntities, customerId, "Test company");

            CustomerOperations.Update(northwindEntities, customerId, "Updated name");

            var customer = CustomerOperations.FindById(northwindEntities, customerId);

            CustomerOperations.Delete(northwindEntities, customerId);

            Assert.AreEqual(customer.CustomerID, customerId);
        }
    }
}
