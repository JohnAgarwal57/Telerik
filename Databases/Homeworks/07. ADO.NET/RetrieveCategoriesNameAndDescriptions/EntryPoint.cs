namespace RetrieveCategoriesNameAndDescriptions
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
                SqlCommand cmdCount = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbCon);
                var allCategories = cmdCount.ExecuteReader();

                using (allCategories)
                {
                    while (allCategories.Read())
                    {
                        string name = (string)allCategories["CategoryName"];
                        string description = (string)allCategories["Description"];
                        Console.WriteLine("{0} - {1}", name, description);
                    }
                }         
            }
        }
    }
}
