using System.Text;

namespace AsymmetriskKrypteringRsaParameterModtager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //virker ikke, den smider en exception når den modtager den krypterede data

            var rsaParameters = new RSAParameterKey();
            string encryptedText;

            try
            {
                Console.WriteLine("RSA parameter");
                Console.WriteLine();

                Console.WriteLine("Indset privat nøgle D");
                rsaParameters.privateKey.D = ByteArrayFromReadLine();
                Console.WriteLine("Indset privat nøgle DP");
                rsaParameters.privateKey.DP = ByteArrayFromReadLine();
                Console.WriteLine("Indset privat nøgle DQ");
                rsaParameters.privateKey.DQ = ByteArrayFromReadLine();
                Console.WriteLine("Indset privat nøgle Exponent");
                rsaParameters.privateKey.Exponent = ByteArrayFromReadLine();
                Console.WriteLine("Indset privat nøgle InverseQ");
                rsaParameters.privateKey.InverseQ = ByteArrayFromReadLine();
                Console.WriteLine("Indset privat nøgle Modulus");
                rsaParameters.privateKey.Modulus = ByteArrayFromReadLine();
                Console.WriteLine("Indset privat nøgle P");
                rsaParameters.privateKey.P = ByteArrayFromReadLine();
                Console.WriteLine("Indset privat nøgle Q");
                rsaParameters.privateKey.Q = ByteArrayFromReadLine();
                Console.WriteLine();

                Console.WriteLine("Indset det krypterede data:");
                encryptedText = Console.ReadLine();

                var rsaDecrypted = rsaParameters.Decrypt(Encoding.UTF8.GetBytes(encryptedText));

                var rsaDecryptedText = Encoding.UTF8.GetString(rsaDecrypted);

                Console.WriteLine();
                Console.WriteLine("Dekryptered tekst: \r\n" + rsaDecryptedText);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Der skete den fejl!");
            }
        }


        private static byte[] ByteArrayFromReadLine()
        {
            string inputData = Console.ReadLine();
            string[] splitString = inputData.Split('-');
            byte[] privateKeyData = new byte[splitString.Length];

            privateKeyData = Encoding.UTF8.GetBytes(inputData);

            return privateKeyData;
        }
    }
}