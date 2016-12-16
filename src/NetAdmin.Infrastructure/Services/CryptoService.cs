using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace NetAdmin.Infrastructure.Services
{
    public class CryptoService : ICryptoService
    {
        private const int Bits = 128;
        private const int IterationCount = 10_000;

        public byte[] GenerateSalt()
        {
            var salt = new byte[Bits / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public byte[] HashPassword(string password, byte[] salt)
        {
            var hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: IterationCount,
                numBytesRequested: Bits / 8);

            return hash;
        }

        public bool VerifyPassword(string password, byte[] salt, byte[] hash)
        {
            var hashedPassword = HashPassword(password, salt);
            return VerifyHashes(hashedPassword, hash);
        }

        public bool VerifyHashes(byte[] firstHash, byte[] secondHash)
        {
            return firstHash.SequenceEqual(secondHash);
        }
    }
}