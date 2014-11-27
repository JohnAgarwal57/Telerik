namespace VehicleListingSystem.MVC.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Hosting;
    using System.Xml;
    using VehicleListingSystem.Data;

    public class XmlParser : IXmlParser
    {
        private readonly XmlDocument doc = new XmlDocument();

        public IQueryable<Vehicle> Parse(string fileName)
        {
            int id = 1;
            this.doc.Load(this.MapPath(fileName));
            XmlNode rootNode = this.doc.DocumentElement;
            var vehicles = new List<Vehicle>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var vehicle = new Vehicle
                {
                    Id = id,
                    Manifacturer = this.GetValue(node, "manifacturer"),
                    Model = this.GetValue(node, "model"),
                    Price = decimal.Parse(this.GetValue(node, "price")),
                    Image = this.GetValue(node, "image")
                };

                vehicles.Add(vehicle);
                id++;
            }

            return vehicles.AsQueryable();
        }

        private string GetValue(XmlNode node, string key)
        {
            string value = string.Empty;

            if (node[key] != null)
            {
                value = node[key].InnerText;
            }

            return value;
        }

        private string MapPath(string seedFile)
        {
            if (HttpContext.Current != null)
            {
                return HostingEnvironment.MapPath(seedFile);
            }

            var absolutePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
            var directoryName = Path.GetDirectoryName(absolutePath);
            var path = Path.Combine(directoryName, string.Format("..{0}", seedFile.TrimStart('~').Replace('/', '\\')));

            return path;
        }
    }
}