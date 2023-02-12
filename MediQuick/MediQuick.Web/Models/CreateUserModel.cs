using MediQuick.Data.Models;

namespace MediQuick.Web.Models
{
    public class CreateUserModel : BaseModel
    {
        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? RepeatPassword { get; set; }

        public int? HospitalId { get; set; }

        public List<int>? RoleIds { get; set; }

        public List<Hospital>? Hospitals { get; set;}

        public List<Role>? Roles { get; set; }
    }
}
