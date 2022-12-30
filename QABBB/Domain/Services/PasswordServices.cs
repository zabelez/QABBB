
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
        byte[] salt = RandomNumberGenerator.GetBytes(12);

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

// hash_config {
//   algorithm: SCRYPT,
//   base64_signer_key: Z2JpPIO9Nn2uhdpvBiA6STvuhrqblngFeIqhSMRGlMNV1sFuKqjJEH9k0pIYn4w6Rzk47+TjfUIiAWGIqI+ZEQ==,
//   base64_salt_separator: Bw==,
//   rounds: 8,
//   mem_cost: 14,
// }

