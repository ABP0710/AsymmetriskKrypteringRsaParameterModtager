using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetriskKrypteringRsaParameterModtager
{
    public class RSAParameterKey
    {
        public RSAParameters privateKey;
        public RSAParameters publicKey;

        /// <summary>
        /// Method for decrypting the cipher,
        /// Create byte arrays to hold the decrypted text,
        /// Create a new instance of RSA,
        /// Import the RSA privateKey information,
        /// Decrypt the byte array and sets OAEP padding
        /// </summary>
        /// <param name="textToEncrypt"></param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] textToEncrypt)
        {
            byte[] decryptedText;

            try
            {
                var rsa = RSA.Create();

                rsa.ImportParameters(privateKey);
                decryptedText = rsa.Decrypt(textToEncrypt, RSAEncryptionPadding.OaepSHA256);

                return decryptedText;
            }
            catch (CryptographicException e)
            {
                Debug.WriteLine(e.Message);

                return null;
            }
        }
    }
}
