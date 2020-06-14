using System;
using System.Collections.Generic;
using System.Text;

namespace Advert.Presistance.Services
{
    public interface IPasswordHasher
    {
        public string Create(string value, string salt);
        public bool Validate(string value, string salt, string hash);
    }
}
