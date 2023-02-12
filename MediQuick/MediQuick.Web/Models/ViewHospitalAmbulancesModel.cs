namespace MediQuick.Web.Models
{
    public class ViewHospitalAmbulancesModel : BaseModel
    {
        public int? HospitalId { get; set; }

        public List<AmbulanceStatus> AmbulanceStatuses { get; set; }
        
    }
}
