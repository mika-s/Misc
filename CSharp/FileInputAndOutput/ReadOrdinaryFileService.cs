using System.IO;
using System.Text;

namespace FileInputAndOutput
{
    public sealed class ReadOrdinaryFileService
    {
        private string fileName;

        public ReadOrdinaryFileService(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Read a file with the FileStream class.
        /// FileStream should be used when we want to read byte[] data.
        /// </summary>
        /// <returns>Text in the file.</returns>
        public string ReadFileWithFileStream()
        {
            FileStream file = File.Open(fileName, FileMode.Open);

            byte[] input = new byte[file.Length];

            file.Read(input, 0, (int)file.Length);
            file.Close();

            string inputAsString = Encoding.UTF8.GetString(input);

            return inputAsString;
        }

        /// <summary>
        /// Read a file with the StreamReader class.
        /// StreamReader should be used when we want to read text data.
        /// </summary>
        /// <returns>Text in the file.</returns>
        public string ReadFileWithStreamReader()
        {
            string inputAsString = string.Empty;

            using (StreamReader fileStream = new StreamReader(fileName))
            {
                inputAsString = fileStream.ReadToEnd();
            }

            return inputAsString;
        }
    }
}
