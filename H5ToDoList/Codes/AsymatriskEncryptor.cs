using System.Security.Cryptography;

namespace H5ToDoList.Codes
{
    public class AsymatriskEncryptor
    {
        public static string Encrypt(string textToEncrypt, string publicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);

                byte[] data = Convert.FromBase64String(textToEncrypt);
                byte[] encryptedData = rsa.Encrypt(data, true);
                string encryptedDataAsString = System.Text.Encoding.UTF8.GetString(encryptedData);

                return encryptedDataAsString;
            }
        }
    }
}
