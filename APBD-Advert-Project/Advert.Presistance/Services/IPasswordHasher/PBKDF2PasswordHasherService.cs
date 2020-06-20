using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Advert.Presistance.Services.IPasswordHasher
{
    public class Pbkdf2PasswordHasherService : IPasswordHasherService
    {
        public string Create(string value, string salt)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                value,
                Encoding.UTF8.GetBytes(salt),
                KeyDerivationPrf.HMACSHA256,
                10000,
                256 / 8);

            return Convert.ToBase64String(valueBytes);
        }

        public string CreateSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

        public bool Validate(string value, string salt, string hash)
        {
            return Create(value, salt) == hash;
        }
    }
}