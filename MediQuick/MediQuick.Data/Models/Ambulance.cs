using MediQuick.Data.Models.TransitionalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Models
{
    public class Ambulance
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public int? PatientId { get; set; }

        public int DestinationHospitalId { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }

        public bool IsAvailable { get; set; }

        public List<AmbulanceDevice> AmbulancesDevices { get; set; }


    }
}
