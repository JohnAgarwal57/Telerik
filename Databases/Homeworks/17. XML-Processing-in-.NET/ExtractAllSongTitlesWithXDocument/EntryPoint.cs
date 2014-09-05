namespace ExtractAllSongTitlesWithXDocument
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class EntryPoint
    {
        private const string Filename = "../../catalogue.xml";

        public static void Main()
        {
            XDocument xmlDoc = XDocument.Load(Filename);
        
            var titles = from album in xmlDoc.Descendants("song")
                select new
                {
                    Title = album.Element("title").Value,
                };

            foreach (var title in titles)
            {
                Console.WriteLine(title.Title);
            }
        }
    }
}
