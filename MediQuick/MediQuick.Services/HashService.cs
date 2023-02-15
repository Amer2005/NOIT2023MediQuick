using MediQuick.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services
{
    public class HashService : IHashService
    {
        public string HashText(string text)
        {
            HashAlgorithm hasher = new SHA1CryptoServiceProvider();
            byte[] textWithSaltBytes = Encoding.UTF8.GetBytes(string.Concat(text));
            byte[] hashedBytes = hasher.ComputeHash(textWithSaltBytes);
            hasher.Clear();
            return Convert.ToBase64String(hashedBytes);
        }
    }
}
