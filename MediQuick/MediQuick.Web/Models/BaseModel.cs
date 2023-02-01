using MediQuick.Data.Models;

namespace MediQuick.Web.Models
{
    public class BaseModel
    {
        public string Message { get; set; }

        public User? User { get; set; }

        public bool Authorised { get; set; }
    }
}
