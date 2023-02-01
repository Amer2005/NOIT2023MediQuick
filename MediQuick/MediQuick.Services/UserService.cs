using MediQuick.Data.Contracts;
using MediQuick.Data.Models;
using MediQuick.Services.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace MediQuick.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool LoginUser(string username, string password)
        {
            if(string.IsNullOrEmpty(username))
            {
                return false;
            }

            if(string.IsNullOrEmpty(password))
            {
                return false;
            }

            password = HashText(password);

            var user = userRepository.GetByUsernameAndPassword(username, password);

            if(user == null)
            {
                return false;
            }

            return true;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            if (string.IsNullOrEmpty(password))
            {
                return null;
            }

            password = HashText(password);

            var user = userRepository.GetByUsernameAndPassword(username, password);

            return user;
        }

        private string HashText(string text)
        {
            HashAlgorithm hasher = new SHA1CryptoServiceProvider();
            byte[] textWithSaltBytes = Encoding.UTF8.GetBytes(string.Concat(text));
            byte[] hashedBytes = hasher.ComputeHash(textWithSaltBytes);
            hasher.Clear();
            return Convert.ToBase64String(hashedBytes);
        }
    }
}