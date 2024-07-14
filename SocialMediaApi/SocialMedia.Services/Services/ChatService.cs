using Microsoft.EntityFrameworkCore;
using SocialMedia.Data.Data;
using SocialMedia.Data.Models;
using SocialMedia.Services.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services.Services
{
    public class ChatService : IChatService
    {
        private readonly AppDbContext _context;
        public ChatService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddCharAsync(Chat chat)
        {
            await _context.AddAsync(chat);
        }

        public Task<IEnumerable<Chat>> GetAllUserChats(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Chat> GetChatAsync(Guid Sender, Guid Receiver)
        {
            return await _context.Chats
                            .Include(c => c.Messages)
                            .FirstOrDefaultAsync(c =>
                                (c.SenderId == Sender && c.ReceiverId == Receiver) ||
                                (c.SenderId == Receiver && c.ReceiverId == Sender));
        }
    }
}
