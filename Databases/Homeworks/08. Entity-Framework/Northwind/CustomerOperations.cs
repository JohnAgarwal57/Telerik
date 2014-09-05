namespace Northwind
{
    using System;
    using System.Linq;

    public class CustomerOperations
    {
        public static void Insert(NorthwindEntities northwindEntities, string customerId, string companyName, string contactName = null, string contactTitle = null, string address = null, string city = null, string region = null, string postalCode = null, string country = null, string phone = null, string fax = null)
        {
            Customer customer = new Customer
            {
                CustomerID = customerId,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };

            northwindEntities.Customers.Add(customer);
            northwindEntities.SaveChanges();
        }

        public static void Update(NorthwindEntities northwindEntities, string id, string companyName, string contactName = null, string contactTitle = null, string address = null, string city = null, string region = null, string postalCode = null, string country = null, string phone = null, string fax = null)
        {
            Customer customer = FindById(northwindEntities, id);
            customer.CompanyName = companyName;
            customer.ContactName = contactName;
            customer.ContactTitle = contactTitle;
            customer.Address = address;
            customer.City = city;
            customer.Region = region;
            customer.PostalCode = postalCode;
            customer.Country = country;
            customer.Phone = phone;
            customer.Fax = fax;

            northwindEntities.SaveChanges();
        }

        public static void Delete(NorthwindEntities northwindEntities, string id)
        {
            Customer customer = FindById(northwindEntities, id);
            northwindEntities.Customers.Remove(customer);
            northwindEntities.SaveChanges();
        }

        public static Customer FindById(NorthwindEntities northwindEntities, string customerId)
        {
            Customer customer = northwindEntities
                .Customers.FirstOrDefault(c => c.CustomerID == customerId);
            return customer;
        }
    }
}
