using MediQuick.Data.Models;

namespace MediQuick.Web.Models
{
    public class AssignPatientModel : BaseModel
    {
        public int AmbulanceId { get; set; }

        public Ambulance Ambulance { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SocialSecurityNumber { get; set; }

        public string Sex { get; set; }

        public string Status { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ExtraInfo { get; set; }
    }
}
