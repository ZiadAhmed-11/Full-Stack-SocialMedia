using SocialMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services.ServiceContracts
{
    public interface ILikeService
    {
        Task AddLikeAsync(Like like);
        Task DeleteLikeAsync(int likeId);
        Task<int> GetPostLikeCount(int PostId);
    }
}
