using SocialMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services.ServiceContracts
{
    public interface IChatService
    {
        Task<Chat> GetChatAsync(Guid Sender, Guid Receiver);
        Task AddCharAsync(Chat chat);
        Task<IEnumerable<Chat>> GetAllUserChats(Guid userId);
    }
}
