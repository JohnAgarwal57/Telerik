namespace ExtractAllSongTitle
{
    using System;
    using System.Xml;

    public class EntryPoint
    {
        private const string Filename = "../../catalogue.xml";

        public static void Main()
        {
            using (XmlReader reader = XmlReader.Create(Filename))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
