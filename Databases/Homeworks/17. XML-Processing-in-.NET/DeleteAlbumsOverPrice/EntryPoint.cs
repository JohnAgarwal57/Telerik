namespace DeleteAlbumsOverPrice
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
            doc.Load(Filename);

            decimal maxPrice = 20;

            XmlNodeList node = Remove(doc.DocumentElement.ChildNodes, maxPrice);

            foreach (XmlNode element in node)
            {
                Console.WriteLine(element["name"].InnerText);
            }
        }

        public static XmlNodeList Remove(XmlNodeList nodeList, decimal maxPrice)
        {
            List<XmlNode> toRemove = new List<XmlNode>();

            foreach (XmlNode xmlElement in nodeList)
            {
                var price = decimal.Parse(xmlElement["price"].InnerText);

                if (price > maxPrice)
                {
                    toRemove.Add(xmlElement);
                }
            }

            foreach (XmlNode xmlElement in toRemove)
            {
                XmlNode node = xmlElement.ParentNode;
                node.RemoveChild(xmlElement);
            }

            return nodeList;
        }
    }
}
