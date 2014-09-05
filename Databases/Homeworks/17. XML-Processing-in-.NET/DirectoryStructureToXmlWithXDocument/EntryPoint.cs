namespace DirectoryStructureToXmlWithXDocument
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    public class EntryPoint
    {
        public static void Main()
        {
            // Change folder to be working!!!
            string sourceDirectory = @"C:\Program Files\Microsoft Visual Studio 12.0\Common7";
            XElement xmlAlbums = new XElement("folders");

            Traverse(sourceDirectory, xmlAlbums);

            Console.WriteLine(xmlAlbums);

            xmlAlbums.Save("../../albums.xml");
        }

        private static void WriteFolder(XElement xmlAlbums, string name)
        {
            XElement xmlDir = new XElement("dir", new XElement("Name", name));

            xmlAlbums.Add(xmlDir);
        }

        private static void WriteFile(XElement xmlAlbums, string name, string size)
        {
            XElement xmlFile = new XElement("file",
                new XElement("Name", name),
                new XElement("Size", size));

            xmlAlbums.Add(xmlFile);
        }

        private static void Traverse(string currentDirectory, XElement xmlAlbums)
        {
            var directories = Directory.EnumerateDirectories(currentDirectory);
            
            foreach (var directory in directories)
            {
                WriteFolder(xmlAlbums, directory);
                Traverse(directory, xmlAlbums);
                var allFiles = Directory.EnumerateFiles(directory, "*.*");

                foreach (var currentFile in allFiles)
                {
                    WriteFile(xmlAlbums, currentFile, currentFile.Length.ToString());
                }
            }
        }
    }
}
