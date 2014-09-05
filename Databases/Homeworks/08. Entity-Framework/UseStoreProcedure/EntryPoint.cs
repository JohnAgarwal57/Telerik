namespace UseStoreProcedure
{
    using System;
    using System.Linq;
    using Northwind;

    class EntryPoint
    {
        static void Main(string[] args)
        {


            NorthwindEntities db = new NorthwindEntities();

            string companyName = "Vaffeljernet";
            var startDate = "1900-01-01";
            var endDate = "2015-01-01";


            var income = db.uspSupplierIncome(companyName, startDate, endDate).First().Income;

            Console.WriteLine("The income of {0} is {1}", companyName, income);
        }
    }
}
