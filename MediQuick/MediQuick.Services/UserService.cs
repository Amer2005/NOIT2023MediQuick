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
        private readonly IRoleRepository roleRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.unitOfWork = unitOfWork;
        }

        public bool LoginUser(string? username, string? password)
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

        public User? GetUserByUsernameAndPassword(string? username, string? password)
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

        public bool CreateUser(string username, string password, int hospitalId, List<int> roles)
        {
            if (userRepository.DoesUserExistByName(username))
            {
                return false;
            }

            if (roles == null)
            {
                return false;
            }

            User user = new User();

            user.Name = username;
            user.Password = HashText(password);
            user.HospitalId = hospitalId;

            userRepository.AddUser(user);

            unitOfWork.Commit();

            User? dbUser = this.GetUserByUsernameAndPassword(username, password);

            if (dbUser == null)
            {
                return false;
            }

            for (int i = 0; i < roles.Count; i++)
            {
                if (roleRepository.GetRoleById(roles[i]) == null)
                {
                    return false;
                }
            }

            for (int i = 0; i < roles.Count; i++)
            {
                userRepository.AddRoleToUser(dbUser.Id, roles[i]);
            }

            unitOfWork.Commit();

            return true;
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