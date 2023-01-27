using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Models
{
    public class Location
    {
        public int Id { get; set; }

        public ICollection<Ambulance> Ambulances { get; set; }

        public ICollection<Hospital> Hospitals { get; set; }

        public ICollection<Patient> Patients { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
