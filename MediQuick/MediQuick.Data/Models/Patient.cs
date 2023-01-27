using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SocialSecurityNumber { get; set; }

        public string Sex { get; set; }

        public string Status { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ExtraInfo { get; set; }

        public List<Cardiogram> Cardiograms { get; set; }
    }
}
