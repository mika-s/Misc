using System.IO;
using System.Security.Cryptography;

namespace FileEncryption
{
    public sealed class HashingService
    {
        public byte[] HashWithSHA256(string path)
        {
            byte[] unhashedBytes = File.ReadAllBytes(path);
            byte[] sha256hashedBytes = new SHA256CryptoServiceProvider().ComputeHash(unhashedBytes);

            return sha256hashedBytes;
        }

        public byte[] HashWithSHA512(string path)
        {
            byte[] unhashedBytes = File.ReadAllBytes(path);
            byte[] sha512hashedBytes = new SHA512CryptoServiceProvider().ComputeHash(unhashedBytes);

            return sha512hashedBytes;
        }

        public byte[] HashWithMD5(string path)
        {
            byte[] unhashedBytes = File.ReadAllBytes(path);
            byte[] md5hashedBytes = new MD5CryptoServiceProvider().ComputeHash(unhashedBytes);

            return md5hashedBytes;
        }
    }
}
