using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace FileInputAndOutput
{
    public sealed class ReadCsvFileService
    {
        private string fileName;
        private string delimiter;
        private Encoding encoding;

        public ReadCsvFileService(string fileName, string delimiter, Encoding encoding)
        {
            this.fileName = fileName;
            this.delimiter = delimiter;
            this.encoding = encoding;
        }

        /// <summary>
        /// Read a column in a CSV file.
        /// </summary>
        /// <param name="columnName">Name of the column to read.</param>
        /// <returns>A string containing the result.</returns>
        public string ReadColumnInCsvFile(string columnName)
        {
            List<string> result = new List<string>();

            using (TextFieldParser parser = new TextFieldParser(fileName, encoding, true))
            {
                parser.TrimWhiteSpace = false;
                parser.Delimiters = new string[] { delimiter };

                // Read the header and look for the wanted column.
                string[] header = parser.ReadFields();

                int headerCounter = 0;
                bool isHeaderFound = false;

                for (headerCounter = 0; headerCounter < header.Length; headerCounter++)
                {
                    if (header[headerCounter] == columnName)
                    {
                        isHeaderFound = true;
                        break;
                    }
                }

                if (isHeaderFound == false)
                    throw new InvalidOperationException($"The header in the CSV file did not contain {columnName}.");

                string[] line;
                while ((line = parser.ReadFields()) != null)
                    result.Add(line[headerCounter]);
            }

            // Make a string out of the result list.
            string resultString = String.Empty;
            foreach (string resultElement in result)
                resultString += $"{resultElement}\n";

            return resultString;
        }
    }
}
