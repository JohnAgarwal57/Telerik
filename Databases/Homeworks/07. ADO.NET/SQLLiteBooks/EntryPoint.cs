namespace SQLLiteBooks
{
    using System;
    using Finisar.SQLite;
    using System.Data;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            SQLiteConnection connection;
            connection = new SQLiteConnection("Data Source=books.db;Version=3;"); 
                        
            ListAllBooks(connection);
            FindBook(connection, "Second");
            AddBook(connection, "My book", "Me", DateTime.Now, "1234567890");
            ListAllBooks(connection);
        }

        private static void ListAllBooks(SQLiteConnection connection)
        {
            connection.Open();

            using (connection)
            {
                SQLiteCommand command = connection.CreateCommand(); 

                string commandText = "select * from Books";

                SQLiteDataAdapter db = new SQLiteDataAdapter(commandText, connection);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                ds.Reset(); 
                db.Fill(ds); 
                dt= ds.Tables[0]; 

                Console.WriteLine("------------------------------");
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        Console.Write("{0}\t", row[column]);
                    }

                    Console.WriteLine();
                }

            Console.WriteLine("------------------------------");
            }
        }

        private static void FindBook(SQLiteConnection connection, string title)
        {
            Console.WriteLine("Found books:");
            connection.Open();
            using (connection)
            {
                SQLiteCommand command = new SQLiteCommand("select * from Books where Title like'%" + title + "%'", connection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Name : {0}, Author : {1}, Publish date : {2}, ISBN : {3}", reader[1], reader[2], reader[3], reader[4]);
                }
            }
        }

        private static void AddBook(SQLiteConnection connection, string title, string author, DateTime publishDate, string isbn)
        {
            connection.Open();
            SQLiteCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO Books(Title, Author, PublishDate, ISBN) VALUES(@Title, @Author, @PublishDate, @ISBN)";
            comm.Parameters.Add("@Title", title);
            comm.Parameters.Add("@Author", author);
            comm.Parameters.Add("@PublishDate", publishDate);
            comm.Parameters.Add("@ISBN", isbn);
            comm.ExecuteNonQuery();
            connection.Close();
        }
    }
}
