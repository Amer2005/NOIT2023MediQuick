namespace MediQuick.Web.Models
{
    public class CreateAmbulanceModel : BaseModel
    {
        public int? HospitalId { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? RepeatPassword { get; set; }
    }
}
