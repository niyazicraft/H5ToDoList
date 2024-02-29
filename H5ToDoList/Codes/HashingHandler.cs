using System.Security.Cryptography;
using System.Text;

namespace H5ToDoList.Codes
{
    public class HashingHandler
    {
        private byte[]? _inputBytes = null;
        public HashingHandler(String TextToHash)
        {

            _inputBytes = Encoding.ASCII.GetBytes(TextToHash);

        }

        public String MD5Hashing()
        {
            MD5 md5 = MD5.Create();
            byte[] hashedvalue = md5.ComputeHash(_inputBytes);
            return Convert.ToBase64String(hashedvalue);
        }

        public String SHAHashing()
        {
            SHA256 sha256 = SHA256.Create();
            byte[] hashedvalue = sha256.ComputeHash(_inputBytes);
            return Convert.ToBase64String(hashedvalue);
        }


        public string HMACHashing() //HMAC er dynamisk, men stadig uden SALT
        {
            HMACSHA256 hmac = new HMACSHA256();
            byte[] myKey = Encoding.ASCII.GetBytes("langtbytearray");
            hmac.Key = myKey;

            byte[] hashedValue = hmac.ComputeHash(_inputBytes);
            return Convert.ToBase64String(hashedValue);
        }

        public string PBKF2Hashing(string salt) //man kunne have alogritmenavn, antal itterationer og bytes her, hvis man vil
        {
            byte[] saltAsByteArray = Encoding.ASCII.GetBytes(salt);
            var hashAlgoritme = new System.Security.Cryptography.HashAlgorithmName("SHA256"); //behøver ikke at være hardcoded

            byte[] hashedValue = Rfc2898DeriveBytes.Pbkdf2(_inputBytes, saltAsByteArray, 8, hashAlgoritme, 32); //8 er antal itterationer, 32 er antal bit
            return Convert.ToBase64String(hashedValue);
        }



        public static string BCryptHashing(string TextToHash)
        {
            return BCrypt.Net.BCrypt.HashPassword(TextToHash, 10, true);
        }

        public static bool BCryptVerfiyHashing(string TextToHash, string HashedValue)
        {
            return BCrypt.Net.BCrypt.Verify(TextToHash, HashedValue, true);
        }

    }
}