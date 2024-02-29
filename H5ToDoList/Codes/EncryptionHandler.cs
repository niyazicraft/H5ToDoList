using Microsoft.AspNetCore.DataProtection;

namespace H5ToDoList.Codes
{
    public class EncryptionHandler
    {
        private readonly IDataProtector _protector;
        public EncryptionHandler(IDataProtectionProvider protector)
        { 
            // This key can be anything, even name of the class
            _protector = protector.CreateProtector("H5ToDoList.Codes.EncryptionHandler");
        }

        public string EncryptSymetrisk(string textToEncrypt) => _protector.Protect(textToEncrypt);

        public string DecryptSymetrisk(string textToEncrypt) => _protector.Unprotect(textToEncrypt);
    }
}
