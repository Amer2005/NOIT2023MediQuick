using MediQuick.Data.Models;

namespace MediQuick.Web.Models
{
    public class ViewAmbulanceModel : BaseModel
    {
        public int? AmbulanceId { get; set; }

        public Ambulance Ambulance { get; set; }
    }
}
