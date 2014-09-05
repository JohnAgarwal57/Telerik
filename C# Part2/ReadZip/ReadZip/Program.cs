namespace ReadZip
{   
    using System;
    using Ionic.Zip;
    using System.IO;
    using System.Data.OleDb;
    using System.Data;

    class Program
    {
        private static string zipToUnpack = @"..\..\Example.zip";
        private static string unpackDirectory = @"..\..\Imports";

        static void Main()
        {
            ExtractFiles(zipToUnpack, unpackDirectory);
            DirSearch(unpackDirectory);
        }

        private static void ExtractFiles(string zipToUnpack, string unpackDirectory)
        {
            using (ZipFile zip1 = ZipFile.Read(zipToUnpack))
            {
                foreach (ZipEntry e in zip1)
                {
                    e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        static void DirSearch(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        ReadValue(f);
                    }
                    DirSearch(d);
                }

                foreach (string f in Directory.GetFiles(sDir))
                {
                    ReadValue(f);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ReadValue(string file)
        {
            string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";

            OleDbConnection con = new OleDbConnection(ConnectionString);

            DataTable dt = new DataTable();

            con.Open();
            OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter("select * from [SHEET1$]", con);
            da.Fill(dt);
            con.Close();

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row[dt.Columns[1]]);
                Console.WriteLine();
            }
        }
    }
}
