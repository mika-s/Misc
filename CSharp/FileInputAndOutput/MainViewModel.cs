using System;
using System.Collections.Generic;
using System.Text;
using FileInputAndOutput.Models;

namespace FileInputAndOutput
{
    public sealed class MainViewModel : ViewModel
    {
        private string fileContent;
        private string csvColumnToRead;
        private List<XmlContent> xmlContentList;
        private ReadOrdinaryFileService readOrdinaryFile;
        private ReadXmlFileService readXmlFile;
        private ReadCsvFileService readCsvFile;
        private WriteToXmlFileService writeXmlFile;

        public MainViewModel()
        {
            readOrdinaryFile = new ReadOrdinaryFileService("..\\..\\Files\\Ordinary textfile.txt");
            readXmlFile = new ReadXmlFileService("..\\..\\Files\\XML file.xml");
            readCsvFile = new ReadCsvFileService("..\\..\\Files\\CSV file.csv", ",", Encoding.ASCII);
            writeXmlFile = new WriteToXmlFileService("..\\..\\Files\\Output XML.xml");

            ReadOrdinaryFileWithFileStreamCommand = new DelegateCommand<string>(ReadOrdinaryFileWithFileStreamExecute);
            ReadOrdinaryFileWithStreamReaderCommand = new DelegateCommand<string>(ReadOrdinaryFileWithStreamReaderExecute);
            ReadOrdinaryFileWithReadAllTextCommand = new DelegateCommand<string>(ReadOrdinaryFileWithReadAllTextExecute);
            ReadXmlFileWithXmlDocumentCommand = new DelegateCommand<string>(ReadXmlFileWithXmlDocumentExecute);
            ReadXmlFileWithLinqCommand = new DelegateCommand<string>(ReadXmlFileWithLinqExecute);
            ReadCsvFileCommand = new DelegateCommand<string>(ReadCsvFileExecute);
            ReadFromXmlFileWithSerializationCommand = new DelegateCommand<string>(ReadFromXmlFileWithSerializationExecute);

            WriteToXmlFileWithSerializationCommand = new DelegateCommand<string>(WriteToXmlFileWithSerializationExecute);
        }

        public DelegateCommand<string> ReadOrdinaryFileWithFileStreamCommand { get; }
        public DelegateCommand<string> ReadOrdinaryFileWithStreamReaderCommand { get; }
        public DelegateCommand<string> ReadOrdinaryFileWithReadAllTextCommand { get; }
        public DelegateCommand<string> ReadXmlFileWithXmlDocumentCommand { get; }
        public DelegateCommand<string> ReadXmlFileWithLinqCommand { get; }
        public DelegateCommand<string> ReadCsvFileCommand { get; }
        public DelegateCommand<string> ReadFromXmlFileWithSerializationCommand { get; }
        public DelegateCommand<string> WriteToXmlFileWithSerializationCommand { get; }

        public string FileContent
        {
            get
            {
                return fileContent;
            }
            set
            {
                if (fileContent != value)
                {
                    fileContent = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<XmlContent> XmlContentList
        {
            get
            {
                return xmlContentList;
            }
            set
            {
                if (xmlContentList != value)
                {
                    xmlContentList = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string CsvColumnToRead
        {
            get
            {
                return csvColumnToRead;
            }
            set
            {
                if (csvColumnToRead != value)
                {
                    csvColumnToRead = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void ReadOrdinaryFileWithFileStreamExecute(string parameter)
        {
            FileContent = readOrdinaryFile.ReadFileWithFileStream();
        }

        private void ReadOrdinaryFileWithStreamReaderExecute(string parameter)
        {
            FileContent = readOrdinaryFile.ReadFileWithStreamReader();
        }

        private void ReadOrdinaryFileWithReadAllTextExecute(string parameter)
        {
            FileContent = readOrdinaryFile.ReadFileWithReadAllText();
        }

        private void ReadXmlFileWithXmlDocumentExecute(string parameter)
        {
            XmlContentList = readXmlFile.ReadXmlFileWithXmlDocument();
        }

        private void ReadXmlFileWithLinqExecute(string parameter)
        {
            XmlContentList = readXmlFile.ReadXmlFileWithLinq();
        }

        private void ReadCsvFileExecute(string parameter)
        {
            try
            {
                FileContent = readCsvFile.ReadColumnInCsvFile(CsvColumnToRead);
            }
            catch (InvalidOperationException)
            {
                FileContent = "Could not find the column header in the CSV file.";
            }
        }

        private void ReadFromXmlFileWithSerializationExecute(string parameter)
        {
            Account readAccount = readXmlFile.DeserializeXmlFromFile<Account>("..\\..\\Files\\Xml file to deserialize.xml");
            FileContent = readAccount.ToString();
        }

        private void WriteToXmlFileWithSerializationExecute(string parameter)
        {
            writeXmlFile.SerializeXmlAndWriteToFile(new Account("testuser", "Test", "Person", DateTime.Now, 200000));
        }
    }
}
