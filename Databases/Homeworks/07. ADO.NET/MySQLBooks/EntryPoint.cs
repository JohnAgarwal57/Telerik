namespace MySqlBooks
{
    using System;
    using MySql.Data.MySqlClient;

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter pass: ");
            string pass = Console.ReadLine();

            string connectionStr = "Server=localhost;Database=books;Uid=root;Pwd=" + pass + ";";
            MySqlConnection connection = new MySqlConnection(connectionStr);

            ListAllBooks(connection);
            FindBook(connection, "Second");
            AddBook(connection, "My book", "Me", DateTime.Now, "1234567890");
            ListAllBooks(connection);
        }

        private static void ListAllBooks(MySqlConnection connection)
        {
            Console.WriteLine("-----------------------------------------------");
            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand("select * from Books", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Name : {0}, Author : {1}, Publish date : {2}, ISBN : {3}", reader[1], reader[2], reader[3], reader[4]);
                }
            }

            Console.WriteLine("-----------------------------------------------");
        }

        private static void FindBook(MySqlConnection connection, string title)
        {
            Console.WriteLine("Found books:");
            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand("select * from Books where Title like'%" + title + "%'", connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Name : {0}, Author : {1}, Publish date : {2}, ISBN : {3}", reader[1], reader[2], reader[3], reader[4]);
                }
            }
        }

        private static void AddBook(MySqlConnection connection, string title, string author, DateTime publishDate, string isbn)
        {
            connection.Open();
            MySqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO Books(Title, Author, PublishDate, ISBN) VALUES(@Title, @Author, @PublishDate, @ISBN)";
            comm.Parameters.AddWithValue("@Title", title);
            comm.Parameters.AddWithValue("@Author", author);
            comm.Parameters.AddWithValue("@PublishDate", publishDate);
            comm.Parameters.AddWithValue("@ISBN", isbn);
            comm.ExecuteNonQuery();
            connection.Close();
        }
    }
}
