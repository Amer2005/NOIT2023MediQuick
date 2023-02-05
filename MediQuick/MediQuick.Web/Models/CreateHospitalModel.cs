namespace MediQuick.Web.Models
{
    public class CreateHospitalModel : BaseModel
    {
        public string? Name { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }
    }
}
