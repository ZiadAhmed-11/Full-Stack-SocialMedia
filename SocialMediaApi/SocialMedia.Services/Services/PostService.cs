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
    public class PostService : IPostService
    {
        private readonly AppDbContext _context;
        public PostService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddPostAsync(Post post)
        {
            post.CreatedAt = DateTime.Now;
            post.UpdatedAt = DateTime.Now;
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }
        public async Task<List<Post>> GetAllPostsOfUserAsync(Guid userId)
        {
            return await _context.Posts
                                 .Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<Post> GetPostById(int postId)
        {
            return await _context.Posts.FindAsync(postId);
            /*                                 .Include(p => p.User)
                                             .Include(p => p.Comments)
                                             .Include(p => p.Likes)
                                             .FirstOrDefaultAsync(p => p.PostId == postId);
            */
        }

        public async Task<int> GetPostLikeCount(int PostId)
        {
            return await _context.Likes.CountAsync(l=>l.PostId==PostId);
        }

        public async Task DeletePost(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Post> UpdatePost(Post post)
        {
            post.UpdatedAt = DateTime.Now;
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }

    }
}
