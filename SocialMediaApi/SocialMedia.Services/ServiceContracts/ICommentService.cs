using SocialMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services.ServiceContracts
{
    public interface ICommentService
    {
        Task AddCommentAsync(Comment comment);
        Task DeleteCommentAsync(int commentId);
        Task<int> GetCommentsCount(int PostId);

    }
}
