using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Services
{
    public class PBKDF2PasswordHasher : IPasswordHasher
    {
        public string Create(string value, string salt)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string value, string salt, string hash)
        {
            throw new NotImplementedException();
        }
    }
}
