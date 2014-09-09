namespace Cars.Operate
{
    using System;
    using System.Linq;

    using Cars.Data;

    internal class EntryPoint
    {
        private const string Connection = "CarsConnection";
        private const string ExpressConnection = "CarsConnectionExpress";
        private const string SearchFile = @"../../../Queries/Queries.xml";
        private const string InputFolder = @"../../../Import";
        private const string ErrorMessage = "Check Data connection or if SQL server is On, or connections string, please!!!!";
        private static ICarsData data;

        private static void Main()
        { 
            try
            {
                Operate(ExpressConnection);
            }
            catch (Exception)
            {
                try
                {
                    Operate(Connection);
                }
                catch (Exception)
                {
                    Console.WriteLine(ErrorMessage);
                }
            }          
        }

        private static void Operate(string connectionstring)
        {
            var jsonImporter = new JsonImporter();
            var xmlSearcher = new XmlSearcher();

            data = new CarsData(connectionstring);

            jsonImporter.Import(data, InputFolder);
            ////xmlSearcher.Search(data, SearchFile);
        }
    }
}
