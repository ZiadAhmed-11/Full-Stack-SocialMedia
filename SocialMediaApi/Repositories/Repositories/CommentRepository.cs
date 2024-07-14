using Microsoft.EntityFrameworkCore;
using SocialMedia.Data.Data;
using SocialMedia.Data.Models;

namespace Repositories.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetCommentsCount(int postId)
        {
            return await _context.Comments
                                 .Where(comment => comment.PostId == postId)
                                 .CountAsync();
        }
    }
}
