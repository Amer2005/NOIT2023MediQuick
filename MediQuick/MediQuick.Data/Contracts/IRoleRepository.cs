using MediQuick.Data.Models;
using System.Collections.Generic;

namespace MediQuick.Data.Contracts
{
    public interface IRoleRepository
    {
        public List<Role> GetAllRoles();
        Role GetRoleById(int id);
    }
}