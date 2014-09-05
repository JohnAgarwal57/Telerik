namespace ExtractArtirstsFromXml
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class EntryPoint
    {
        private const string Filename = "../../catalogue.xml";

        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            var artists = new Dictionary<string, int>();
            
            doc.Load(Filename);
            
            XmlNode rootNode = doc.DocumentElement;
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var artist = node["artist"].InnerText;

                if (!artists.ContainsKey(artist))
                {
                    artists[artist] = 1;
                }
                else
                {
                    artists[artist]++;
                }
            }

            foreach (var artist in artists)
            {
                Console.WriteLine("The artist {0} has {1} albums in the catalogue", artist.Key, artist.Value);
            }
        }
    }
}
