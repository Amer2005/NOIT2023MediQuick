using MediQuick.Web.Models.Enums;

namespace MediQuick.Web.Models
{
    public class Message
    {
        public Message(string text, MessageType type)
        {
            Text = text;
            Type = type;
        }

        public MessageType Type { get; set; }

        public string? Text { get; set; }
    }
}
