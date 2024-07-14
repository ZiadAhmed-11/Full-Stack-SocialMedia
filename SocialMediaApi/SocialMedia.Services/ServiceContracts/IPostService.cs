using SocialMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services.ServiceContracts
{
    public interface IPostService
    {
        Task AddPostAsync(Post post);
        Task <List<Post>> GetAllPostsAsync();
        Task<List<Post>> GetAllPostsOfUserAsync(Guid UserId);
        Task<Post> GetPostById(int PostId);
        Task DeletePost(int PostId);
        Task<Post> UpdatePost(Post post);
    }
}
