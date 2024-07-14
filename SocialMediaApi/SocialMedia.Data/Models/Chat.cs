using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.Models
{
    public class Chat
    {
        public int Id { get; set; }

        public Guid SenderId { get; set; }
        public User? SenderUser { get; set; }

        public Guid ReceiverId { get; set; }
        public User? ReceiverUser { get; set; }

        public virtual IEnumerable<Message> Messages { get; set; } = new List<Message>();
    }
}
