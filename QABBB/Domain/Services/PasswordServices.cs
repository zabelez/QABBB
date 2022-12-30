
using System.Security.Cryptography;
using System.Text;

namespace QABBB.Domain.Services
{
    public class PasswordServices
    {
        public PasswordServices(){}

        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        byte[] salt = Encoding.ASCII.GetBytes("Gj+6c0At!#eWn@DUnzM4T)bJQWRH?5(V!OFb@nH8");

        public string HashPasword(string password)
        {

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                this.salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }
    }
}