using MediQuick.Data.Models;

namespace MediQuick.Data.Contracts
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUserById(int id);
        bool DoesUserExistByName(string username);
        User GetByUsernameAndPassword(string username, string password);
        User GetUserById(int id);

        void AddRoleToUser(int userId, int roleId);
    }
}