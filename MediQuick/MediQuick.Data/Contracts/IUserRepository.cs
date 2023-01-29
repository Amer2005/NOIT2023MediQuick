using MediQuick.Data.Models;

namespace MediQuick.Data.Contracts
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void DeleteUserById(int id);
        User GetUserById(int id);
    }
}