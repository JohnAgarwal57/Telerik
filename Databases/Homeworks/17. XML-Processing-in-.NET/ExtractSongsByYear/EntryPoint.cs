namespace ExtractSongsByYear
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class EntryPoint
    {
        private const string Filename = "../../catalogue.xml";
        private const int Years = 5;
        private const string XPathQuery = "catalogue/album";

        public static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            var albums = new Dictionary<string, double>();
            xmlDoc.Load(Filename);
            string xPathQuery = XPathQuery;

            XmlNodeList xmlAlbums = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode album in xmlAlbums)
            {
                var year = album.SelectSingleNode("year").InnerText;
                var albumName = album.SelectSingleNode("name").InnerText;
                var price = album.SelectSingleNode("price").InnerText;

                if (int.Parse(year) <= DateTime.Now.Year - Years)
                {
                    albums[albumName] = double.Parse(price);
                }
            }

            foreach (var album in albums)
            {
                Console.WriteLine("The album {0} has price {1}.", album.Key, album.Value);
            }
        }
    }
}
