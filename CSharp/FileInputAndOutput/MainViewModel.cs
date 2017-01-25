using System;
using System.Collections.Generic;
using System.Text;

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

        public MainViewModel()
        {
            readOrdinaryFile = new ReadOrdinaryFileService("..\\..\\Files\\Ordinary textfile.txt");
            readXmlFile = new ReadXmlFileService("..\\..\\Files\\XML file.xml");
            readCsvFile = new ReadCsvFileService("..\\..\\Files\\CSV file.csv", ",", Encoding.ASCII);

            ReadOrdinaryFileWithFileStreamCommand = new DelegateCommand<string>(ReadOrdinaryFileWithFileStreamExecute);
            ReadOrdinaryFileWithStreamReaderCommand = new DelegateCommand<string>(ReadOrdinaryFileWithStreamReaderExecute);
            ReadXmlFileCommand = new DelegateCommand<string>(ReadXmlFileExecute);
            ReadCsvFileCommand = new DelegateCommand<string>(ReadCsvFileExecute);
        }

        public DelegateCommand<string> ReadOrdinaryFileWithFileStreamCommand { get; private set; }

        public DelegateCommand<string> ReadOrdinaryFileWithStreamReaderCommand { get; private set; }

        public DelegateCommand<string> ReadXmlFileCommand { get; private set; }

        public DelegateCommand<string> ReadCsvFileCommand { get; private set; }

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

        private void ReadXmlFileExecute(string parameter)
        {
            XmlContentList = readXmlFile.ReadXmlFile();
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
    }
}
