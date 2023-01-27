using MediQuick.Data.Models.TransitionalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediQuick.Data.Models
{
    public class Device
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<AmbulanceDevice> AmbulancesDevices { get; set; }
    }
}
