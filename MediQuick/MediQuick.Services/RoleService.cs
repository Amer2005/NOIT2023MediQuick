using MediQuick.Data.Contracts;
using MediQuick.Data.Models;
using MediQuick.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services
{
    public class RoleService : IRoleService
    {
        private IRoleRepository roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public List<Role> GetAllRoles()
        {
            return roleRepository.GetAllRoles();
        }

        public Role GetRoleByName(string name)
        {
            return roleRepository.GetRoleByName(name);
        }
    }
}
