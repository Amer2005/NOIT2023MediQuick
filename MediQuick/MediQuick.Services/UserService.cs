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

        public void LoginUser(string? username, string? password)
        {
            if(string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("The username cannot be empty!");
            }

            if(string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("The password cannot be empty!");
            }

            password = HashText(password);

            var user = userRepository.GetByUsernameAndPassword(username, password);

            if(user == null)
            {
                throw new ArgumentException("Wrong username or password!");
            }
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

        public void CreateUser(string username, string password, int hospitalId, List<int> roles)
        {
            if (userRepository.DoesUserExistByName(username))
            {
                throw new ArgumentException("User by that name already exists!");
            }

            if (roles == null || roles.Count == 0)
            {
                throw new ArgumentException("Roles cannot be empty!");
            }

            User user = new User();

            user.Name = username;
            user.Password = HashText(password);
            user.HospitalId = hospitalId;

            userRepository.AddUser(user);

            unitOfWork.Commit();

            if (user == null)
            {
                throw new NullReferenceException("User is null!");
            }

            for (int i = 0; i < roles.Count; i++)
            {
                if (roleRepository.GetRoleById(roles[i]) == null)
                {
                    throw new Exception("Role was not found!");
                }
            }

            for (int i = 0; i < roles.Count; i++)
            {
                userRepository.AddRoleToUser(user.Id, roles[i]);
            }

            unitOfWork.Commit();
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