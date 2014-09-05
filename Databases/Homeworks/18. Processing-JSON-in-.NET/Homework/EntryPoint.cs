namespace Homework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml;
    using HtmlTags;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class EntryPoint
    {
        private const string SourceFile = "http://forums.academy.telerik.com/feed/qa.rss";
        private static readonly string DestinationFile = string.Format("{0}{1}", Directory.GetCurrentDirectory(), @"\qa.xml");
        private static readonly WebClient MyWebClient = new WebClient();
        private static readonly XmlDocument Doc = new XmlDocument();
        private static readonly List<ForumItem> ForumItems = new List<ForumItem>();
        private static readonly StringBuilder Html = new StringBuilder();

        public static void Main(string[] args)
        {
            MyWebClient.DownloadFile(SourceFile, DestinationFile);
            Doc.Load(DestinationFile);

            var jsonFromXml = JsonConvert.SerializeXmlNode(Doc);

            var jsonObj = JObject.Parse(jsonFromXml);

            var items = jsonObj["rss"]["channel"]["item"];

            CreatePoco(items);

            GenerateHtml();
        }

        private static void CreatePoco(JToken items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item["title"]);

                ForumItem forumItem = new ForumItem
                {
                    Title = item["title"].ToString(),
                    Link = item["link"].ToString(),
                    Category = item["category"].ToString()
                };

                ForumItems.Add(forumItem);
            }
        }

        private static void GenerateHtml()
        {
            foreach (var item in ForumItems)
            {
                var span = new HtmlTag("span");
                span.Text(string.Format("{0} ", item.Category));

                var anchor = new HtmlTag("a");
                anchor.Text(item.Title);
                anchor.Attr(string.Format("href = {0}", item.Link));

                var br = new HtmlTag("br");

                Html.Append(span);
                Html.Append(anchor);
                Html.Append(br);
            }

            using (StreamWriter sw = new StreamWriter(File.Open("items.html", FileMode.Create), Encoding.Unicode))
            {
                sw.WriteLine(Html.ToString());
            }
        }
    }
}