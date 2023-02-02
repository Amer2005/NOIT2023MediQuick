using MediQuick.Data.Contracts;
using MediQuick.Data.Models;
using MediQuick.Data.Models.TransitionalModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMediQuickDbContext dbContext;

        public UserRepository(IMediQuickDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            return dbContext.Users.Include(x => x.UsersRoles).ThenInclude(x => x.Role).FirstOrDefault(x => x.Name == username && x.Password == password);
        }

        public User GetUserById(int id)
        {
            return dbContext.Users.Include(x => x.UsersRoles).ThenInclude(x => x.Role).FirstOrDefault(x => x.Id == id);
        }

        public void AddUser(User user)
        {
            dbContext.Users.Add(user);
        }

        public bool DoesUserExistByName(string username)
        {
            if (dbContext.Users.Any(x => x.Name == username))
            {
                return true;
            }

            return false;
        }

        public void DeleteUserById(int id)
        {
            dbContext.Users.Remove(this.GetUserById(id));
        }

        public void AddRoleToUser(int userId, int roleId)
        {
            dbContext.UsersRoles.Add(new UserRole() { RoleId = roleId, UserId = userId });
        }
    }
}
