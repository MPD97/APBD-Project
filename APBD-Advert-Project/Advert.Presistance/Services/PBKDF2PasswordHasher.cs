using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Advert.Presistance.Services
{
    public class PBKDF2PasswordHasher : IPasswordHasher
    {
        public string Create(string value, string salt)
        {
            throw new NotImplementedException();
        }

        public string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

        public bool Validate(string value, string salt, string hash)
        {
            throw new NotImplementedException();
        }
    }
}
