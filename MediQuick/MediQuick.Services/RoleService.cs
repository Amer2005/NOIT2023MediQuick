using MediQuick.Data.Contracts;
using MediQuick.Data.Enums;
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

        public List<Role> GetSpecificRoles(List<RoleType> roles)
        {
            return roleRepository
                .GetAllRoles()
                .Where(x => roles
                    .Select(y => y.ToString())
                    .Contains(x.Name)).ToList();
        }

        public Role GetRoleById(int id)
        {
            return roleRepository.GetRoleById(id);
        }

        public Role GetRoleByName(string name)
        {
            return roleRepository.GetRoleByName(name);
        }
    }
}
