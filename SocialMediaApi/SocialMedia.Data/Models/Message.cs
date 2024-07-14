using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime DateSent { get; set; }
        public string? Text { get; set; }

        public int ChatId { get; set; }
        public Chat? Chat { get; set; }

        public Guid SenderUserId { get; set; }
        public User? SenderUser { get; set; }

        public Guid ReceiverUserId { get; set; }
        public User? ReceiverUser { get; set; }
    }
}
