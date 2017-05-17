using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Obfuscation.Core.Helpers
{
    public class DesAlgorithm
    {
        private readonly DESCryptoServiceProvider desProvider;

        public DesAlgorithm(string password)
        {
            if (password.Length < 8)
            {
                var extraSymbols = new char[8 - password.Length];
                password = password + extraSymbols;
            }
            byte[] keyhash = SHA256.Create().ComputeHash(Encoding.Default.GetBytes(password));
            Array.Resize(ref keyhash, DES.Create().KeySize / 8);
            desProvider = new DESCryptoServiceProvider
            {
                Key = keyhash,
                IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }
            };
        }

        public string EncryptString(string source)
        {
            return Encoding.Default.GetString(EncryptStringToBytes(source));
        }

        public string DecryptString(string encrypted)
        {
            var textAsBytes = Encoding.Default.GetBytes(encrypted);

            return DecryptStringFromBytes(textAsBytes);
        }

        private byte[] EncryptStringToBytes(string originalText)
        {
            if (originalText == null)
            {
                throw new ArgumentNullException(nameof(originalText));
            }

            byte[] encrypted;
            ICryptoTransform encryptor = desProvider.CreateEncryptor();
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(originalText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            return encrypted;
        }

        private string DecryptStringFromBytes(byte[] cipherText)
        {
            if (cipherText == null)
            {
                throw new ArgumentNullException(nameof(cipherText));
            }

            try
            {
                string decryptedText = null;
                ICryptoTransform decryptor = desProvider.CreateDecryptor();

                using (var textMemoryStream = new MemoryStream(cipherText))
                {
                    using (var decryptionStream = new CryptoStream(textMemoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var decryptedTextStream = new StreamReader(decryptionStream))
                        {
                            decryptedText = decryptedTextStream.ReadToEnd();
                        }
                    }
                }

                return decryptedText;
            }
            catch (Exception ex)
            {
                // log?
            }

            return null;
        }


    }
}
