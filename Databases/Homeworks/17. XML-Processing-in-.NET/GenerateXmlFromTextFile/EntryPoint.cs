namespace GenerateXmlFromTextFile
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    public class EntryPoint
    {
        private const string TextFileName = "../../persons.txt";

        public static void Main()
        {
            string line;
            XElement persons = new XElement("persons");

            try
            {
                using (StreamReader file = new StreamReader(TextFileName))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        var personAtributes = line.Split(',');
                        XElement person = new XElement("person",
                            new XElement("Name", personAtributes[0]),
                            new XElement("Address", personAtributes[1]),
                            new XElement("Phone", personAtributes[2]));

                        persons.Add(person);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(persons);

            persons.Save("../../persons.xml");   
        }
    }
}
