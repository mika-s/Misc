using System.IO;

namespace FileEncryption
{
    public sealed class EncryptionService
    {
        /// <summary>
        /// Encrypt file using File.Encrypt() in .NET.
        /// 
        /// "Both the Encrypt method and the Decrypt method use the
        /// cryptographic service provider (CSP) installed on the computer
        /// and the file encryption keys of the process calling the method."
        /// </summary>
        public void EncryptFile(string path)
        {
            File.Encrypt(path);
        }

        /// <summary>
        /// Decrypt file using File.Decrypt() in .NET.
        /// 
        /// "Both the Encrypt method and the Decrypt method use the
        /// cryptographic service provider (CSP) installed on the computer
        /// and the file encryption keys of the process calling the method."
        /// </summary>
        public void DecryptFile(string path)
        {
            File.Decrypt(path);
        }
    }
}
