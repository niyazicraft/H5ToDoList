using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography;

namespace H5ToDoList.Codes
{
    public class SymetriskEncryptionHandler
    {
        private readonly IDataProtector _protector;
        public SymetriskEncryptionHandler(IDataProtectionProvider protector)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                _protector = protector.CreateProtector(rsa.ToXmlString(false));

            }
        }

        public string EncryptSymetrisk(string textToEncrypt) => _protector.Protect(textToEncrypt);

        public string DecryptSymetrisk(string textToEncrypt) => _protector.Unprotect(textToEncrypt);
    }
}
