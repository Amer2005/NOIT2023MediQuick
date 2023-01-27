using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Models.TransitionalModels
{
    public class AmbulanceDevice
    {
        public int AmbulanceId { get; set; }

        public Ambulance Ambulance { get; set; }

        public int DeviceId { get; set; }

        public Device Device { get; set; }
    }
}
