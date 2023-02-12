using MediQuick.Data.Enums;
using MediQuick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Services.Contracts
{
    public interface IRoleService
    {
        List<Role> GetAllRoles();
        Role GetRoleById(int id);
        Role GetRoleByName(string name);
        List<Role> GetSpecificRoles(List<RoleType> roles);
    }
}
