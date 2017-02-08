using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace FileInputAndOutput
{
    public sealed class ReadXmlFileService
    {
        private string fileName;

        public ReadXmlFileService(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Read the XML file with XmlDocument and store the content in a list of XmlContent objects.
        /// </summary>
        public List<XmlContent> ReadXmlFileWithXmlDocument()
        {
            List<XmlContent> content = new List<XmlContent>();

            XmlDocument xmlFile = new XmlDocument();
            xmlFile.Load(fileName);

            XmlNodeList childElementsNodes = xmlFile.DocumentElement.SelectNodes("/RootElement/ChildElements//ChildElement");

            foreach (XmlNode childElementNode in childElementsNodes)
            {
                XmlNode childValue1Node = childElementNode.SelectSingleNode("./ChildValue[@Name='ChildValue1']");
                XmlNode childValue2Node = childElementNode.SelectSingleNode("./ChildValue[@Name='ChildValue2']");
                XmlNode childValue3Node = childElementNode.SelectSingleNode("./ChildValue[@Name='ChildValue3']");

                int childValue1 = Int32.Parse(childValue1Node.Attributes["Value"].Value, CultureInfo.InvariantCulture);
                string childValue2 = childValue2Node.Attributes["Value"].Value;
                XmlEnumValues childValue3 = (XmlEnumValues)Enum.Parse(typeof(XmlEnumValues), childValue3Node.Attributes["Value"].Value);

                XmlContent contentElement = new XmlContent(childValue1, childValue2, childValue3);
                content.Add(contentElement);
            }

            return content;
        }

        /// <summary>
        /// Read the XML file with Linq and store the content in a list of XmlContent objects.
        /// </summary>
        public List<XmlContent> ReadXmlFileWithLinq()
        {
            List<XmlContent> content = new List<XmlContent>();

            XDocument xmlFile = XDocument.Load(fileName);

            var childElements = from childElement in xmlFile.Descendants("ChildElement")
                                select new
                                {
                                    ChildValues = childElement.Descendants("ChildValue"),
                                };

            foreach (var childElement in childElements)
            {
                var childValue1q = childElement.ChildValues.Where(p => p.Attribute("Name").Value == "ChildValue1").Select(p => p).First();
                int childValue1 = Int32.Parse(childValue1q.Attribute("Value").Value);

                var childValue2q = childElement.ChildValues.Where(p => p.Attribute("Name").Value == "ChildValue2").Select(p => p).First();
                string childValue2 = childValue2q.Attribute("Value").Value;

                var childValue3q = childElement.ChildValues.Where(p => p.Attribute("Name").Value == "ChildValue3").Select(p => p).First();
                XmlEnumValues childValue3 = (XmlEnumValues)Enum.Parse(typeof(XmlEnumValues), childValue3q.Attribute("Value").Value);

                content.Add(new XmlContent(childValue1, childValue2, childValue3));
            }

            return content;
        }
    }
}
