using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

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
        /// Read the XML file and store the content in a list of XmlContent objects.
        /// </summary>
        public List<XmlContent> ReadXmlFile()
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
    }
}
