namespace RetrieveCategoriesAndProductsInCategory
{
    using System;
    using System.Data.SqlClient;

    public class EntryPoint
    {
        private const string ConnectionString = "Server=.\\SQLEXPRESS; " + "Database=NorthWind; Integrated Security=true";

        public static void Main(string[] args)
        {         
            SqlConnection dbCon = new SqlConnection(ConnectionString);

            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdCount = 
                    new SqlCommand("Select * from Categories inner join Products on Categories.CategoryID = Products.CategoryID order by Categories.CategoryName, Products.ProductName", dbCon);
                
                var allProducts = cmdCount.ExecuteReader();

                using (allProducts)
                {
                    while (allProducts.Read())
                    {
                        string name = (string)allProducts["CategoryName"];
                        string description = (string)allProducts["ProductName"];
                        Console.WriteLine("{0} - {1}", name, description);
                    }
                }             
            }
        }
    }
}