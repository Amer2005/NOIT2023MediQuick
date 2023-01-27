using MediQuick.Data.Models.TransitionalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<UserRole> UsersRoles { get; set; }
    }
}
