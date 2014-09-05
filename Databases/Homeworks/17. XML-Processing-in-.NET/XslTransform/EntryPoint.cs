namespace XslTransform
{
    using System;
    using System.Xml.Xsl;

    public class EntryPoint
    {
        private const string XmlFilename = "../../catalogue.xml";
        private const string XslFilename = "../../catalogue.xsl";
        private const string HtmlFilename = "../../catalogue.html";

        public static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(XslFilename);
            xslt.Transform(XmlFilename, HtmlFilename);
        }
    }
}
