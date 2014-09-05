namespace NumberOfCategoriesRows
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
                SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) FROM Categories", dbCon);
                int categoriesCount = (int)cmdCount.ExecuteScalar();

                Console.WriteLine("The number of rows in table Categories is {0}", categoriesCount);
            }
        }
    }
}
