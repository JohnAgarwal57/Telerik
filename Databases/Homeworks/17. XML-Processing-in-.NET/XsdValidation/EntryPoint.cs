namespace XsdValidation
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;

    public class EntryPoint
    {
        private const string XsdInvalidFileName = "../../Invalidcatalogue.xsd";
        private const string XmlInvalidFileName = "../../Invalidcatalogue.xml";
        private const string XsdFileName = "../../catalogue.xsd";
        private const string XmlFileName = "../../catalogue.xml";
        private const string SuccessMessage = "The document {0} validated against {1} is valid.";
        private const string FailMessage = "The document {0} validated against {1} is NOT valid.";

        private static bool isValid = true;

        static void Main()
        {
            Validate(XsdFileName, XmlFileName);
            Validate(XsdInvalidFileName, XmlInvalidFileName);
        }

        private static void Validate(string xsdFile, string xmlFile)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, xsdFile);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += Handler;
            
            XmlDocument document = new XmlDocument();
            document.Load(xmlFile);
            XmlReader reader = XmlReader.Create(new StringReader(document.InnerXml), settings);

            while (reader.Read())
            {
            }

            if (isValid)
            {
                Console.WriteLine(SuccessMessage, xmlFile, xsdFile);
            }
            else
            {
                Console.WriteLine(FailMessage, xmlFile, xsdFile);
            }
        }

        private static void Handler(object sender, ValidationEventArgs e)
        {
            isValid = false;       
        }
    }
}
