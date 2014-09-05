namespace DirectoryStructureToXml
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class EntryPoint
    {
        public static void Main()
        {
            // Change folder to be working!!!
            string sourceDirectory = @"C:\Program Files\Microsoft Visual Studio 12.0\Common7";

            string fileName = "../../folderAndFiles.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");

            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
        
                writer.WriteStartDocument();
                writer.WriteStartElement("directory");
                writer.WriteAttributeString("name", sourceDirectory);

                Traverse(sourceDirectory, writer);

                writer.WriteEndDocument();
            }        
        }

        private static void WriteFolder(XmlWriter writer, string name)
        {
            writer.WriteStartElement("dir");
            writer.WriteElementString("name", name);
            writer.WriteEndElement();
        }

        private static void WriteFile(XmlWriter writer, string name, string size)
        {
            writer.WriteStartElement("file");
            writer.WriteElementString("name", name);
            writer.WriteElementString("size", size);
            writer.WriteEndElement();
        }

        private static void Traverse(string currentDirectory, XmlTextWriter writer)
        {
            var directories = Directory.EnumerateDirectories(currentDirectory);
            
            foreach (var directory in directories)
            {
                WriteFolder(writer, directory);
                Traverse(directory, writer);
                var allFiles = Directory.EnumerateFiles(directory, "*.*");

                foreach (string currentFile in allFiles)
                {
                    WriteFile(writer, currentFile, currentFile.Length.ToString());
                }
            }
        }
    }
}
