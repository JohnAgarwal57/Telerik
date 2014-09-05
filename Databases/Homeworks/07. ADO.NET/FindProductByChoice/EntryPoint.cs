namespace FindProductByChoice
{
   using System;
    using System.Data.SqlClient;
using System.Text.RegularExpressions;

    public class EntryPoint
    {
        private const string ConnectionString = "Server=.\\SQLEXPRESS; " + "Database=NorthWind; Integrated Security=true";

        public static void Main(string[] args)
        {
            var product = Console.ReadLine();

            product = CleanInput(product);
            
            SqlConnection dbCon = new SqlConnection(ConnectionString);

            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdCount = new SqlCommand("SELECT * FROM Products where ProductName like '%" + product + "%'", dbCon);
                var allCategories = cmdCount.ExecuteReader();

                using (allCategories)
                {
                    while (allCategories.Read())
                    {
                        string name = (string)allCategories["ProductName"];
                        string quantity = (string)allCategories["QuantityPerUnit"];
                        Console.WriteLine("{0} - {1}", name, quantity);
                    }
                }              
            }        
        }

        private static string CleanInput(string strIn)
        {
            try 
            {
                return Regex.Replace(strIn, @"[^\w\.@_@%@']", string.Empty, RegexOptions.None, TimeSpan.FromSeconds(1.5)); 
            }
            catch (RegexMatchTimeoutException) 
            {
                return string.Empty;   
            }
        }
    }
}