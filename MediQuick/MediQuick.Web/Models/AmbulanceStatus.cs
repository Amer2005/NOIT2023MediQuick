namespace MediQuick.Web.Models
{
    public class AmbulanceStatus
    {
        public AmbulanceStatus(string driverName, bool hasPatient, int ambulanceId)
        {
            DriverName = driverName;
            HasPatient = hasPatient;
            AmbulanceId = ambulanceId;
        }

        public string DriverName { get; set; }

        public bool HasPatient { get; set; }

        public int AmbulanceId { get; set; }
    }
}
