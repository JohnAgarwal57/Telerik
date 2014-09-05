namespace ExtractSongByYearWithLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class EntryPoint
    {
        private const string Filename = "../../catalogue.xml";
        private const int Years = 5;

        public static void Main()
        {
            XDocument xmlDoc = XDocument.Load(Filename);

            var albums = from album in xmlDoc.Descendants("album")
                         where (int.Parse(album.Element("price").Value) <= (DateTime.Now.Year - Years))
                         select new
                         {
                             AlbumName = album.Element("name").Value,
                             AlbumPrice = album.Element("price").Value,
                         };

            foreach (var album in albums)
            {
                Console.WriteLine("The album {0} has price {1}.", album.AlbumName, album.AlbumPrice);
            }
        }
    }
}
