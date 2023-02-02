using MediQuick.Data.Models;

namespace MediQuick.Web.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            this.AllowedRoles = new List<string>();
            this.Messages = new List<Message>();
        }

        public List<Message>? Messages { get; set; }

        public User? User { get; set; }

        public bool Authorised { get; set; }

        public List<string>? AllowedRoles { get; set; }
    }
}
