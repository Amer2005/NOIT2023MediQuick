using MediQuick.Data.Contracts;
using MediQuick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IMediQuickDbContext dbContext;

        public RoleRepository(IMediQuickDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Role> GetAllRoles()
        {
            return dbContext.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return dbContext.Roles.FirstOrDefault(x => x.Id == id);
        }
    }
}
