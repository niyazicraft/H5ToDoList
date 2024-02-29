using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace H5ToDoList.Codes
{
    public class AsymatriskEncryptionHandler
    {
        private string _privatekey;
        private string _publickey;
        public AsymatriskEncryptionHandler()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                _privatekey = rsa.ToXmlString(true);
                _privatekey = rsa.ToXmlString(false);
            }
        }

        public string EncryptAsymatrisk(string textToEncrypt)
        {
            return AsymatriskEncryptor.Encrypt(textToEncrypt, _publickey);
        }

        public string DecryptAsymatrisk(string textToDecrypt)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(_privatekey);
                byte[] data = Convert.FromBase64String(textToDecrypt);
                byte[] decryptedData = rsa.Encrypt(data, true);
                var decryptedDataAsString = System.Text.Encoding.UTF8.GetString(decryptedData);
                return decryptedDataAsString;
            }
        }
    }
}
