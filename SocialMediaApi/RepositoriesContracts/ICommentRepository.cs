using SocialMedia.Data.Models;

namespace RepositoriesContracts
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);
        Task DeleteCommentAsync(int commentId);
        Task<int> GetCommentsCount(int postId);
    }
}
