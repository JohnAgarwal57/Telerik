namespace ExtractsArtistsFromXmlUsingXpath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class EntryPoint
    {
        public static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();          
            var artists = new Dictionary<string, int>();
            xmlDoc.Load("../../catalogue.xml");
            string xPathQuery = "catalogue/album";
        
            XmlNodeList albums = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode album in albums)
            {
                var artist = album.SelectSingleNode("artist").InnerText;

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
