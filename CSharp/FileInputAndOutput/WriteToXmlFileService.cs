using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace FileInputAndOutput
{
    public sealed class WriteToXmlFileService
    {
        private string fileName;

        public WriteToXmlFileService(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Write to XML file by serializion of an object with DataContractSerializer.
        /// </summary>
        public void SerializeXmlAndWriteToFile<T>(T objToWrite)
        {
            var serializer = new DataContractSerializer(typeof(T));
            var settings = new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true };

            using (var xw = XmlWriter.Create(fileName, settings))
            {
                serializer.WriteObject(xw, objToWrite);
            }
        }
    }
}
