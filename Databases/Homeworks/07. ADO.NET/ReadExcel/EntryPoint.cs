namespace ReadExcel
{
    using System;
    using System.Data;
    using System.Data.OleDb;

    public class EntryPoint
    {
        private const string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Excel.xlsx;Extended Properties=\"Excel 8.0;HDR=YES;\"";
        
        public static void Main(string[] args)
        {
            OleDbConnection con = new OleDbConnection(ConnectionString);

            ShowValues(con);  
      
            string name = "Pesho";
            string score = "66666";

            AddRow(con, name, score);

            ShowValues(con);
        }

        private static void ShowValues(OleDbConnection con)
        {
            DataTable dt = new DataTable();

            con.Open();
            OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter("select * from [SHEET1$]", con);
            da.Fill(dt);
            con.Close();

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

        private static void AddRow(OleDbConnection myConn, string name, string score)
        {
            string sqlinsert = "INSERT INTO [Sheet1$] VALUES ('" + name + "','" + score + "')";

            OleDbCommand sqlInsert = new OleDbCommand(sqlinsert, myConn);
            myConn.Open();
            sqlInsert.ExecuteNonQuery();
            myConn.Close();
        }
    }
}