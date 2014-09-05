namespace RetrieveAndStoreImages
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing.Imaging;
    using System.IO;

    public class EntryPoint
    {
        private const string ConnectionString = "Server=.\\SQLEXPRESS; " + "Database=NorthWind; Integrated Security=true";

        public static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection(ConnectionString);

            ExtractImagesFromDB(dbCon);
        }

        private static void ExtractImagesFromDB(SqlConnection dbConn)
        {
            dbConn.Open();
            using (dbConn)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Categories ", dbConn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    byte[] rawData = (byte[])reader["Picture"];
                    string fileName = reader["CategoryName"].ToString().Replace('/', '_') + ".jpg";
                    int len = rawData.Length;
                    int header = 78;
                    byte[] imgData = new byte[len - header];
                    Array.Copy(rawData, 78, imgData, 0, len - header);
 
                    MemoryStream memoryStream = new MemoryStream(imgData);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
                    image.Save(new FileStream(fileName, FileMode.Create), ImageFormat.Jpeg);

                    // Check RetrieveAndStoreImages\bin\Debug
                }
            }
        }
    }
}