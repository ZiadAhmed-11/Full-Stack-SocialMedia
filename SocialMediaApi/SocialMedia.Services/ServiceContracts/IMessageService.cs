using SocialMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services.ServiceContracts
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetChatMessagesByIdAsync(int chatId);
        Task AddMessageAsync(Message message);
    }
}
