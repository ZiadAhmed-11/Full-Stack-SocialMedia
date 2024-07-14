using Microsoft.EntityFrameworkCore;
using Repositories;
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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await _commentRepository.AddCommentAsync(comment);
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            await _commentRepository.DeleteCommentAsync(commentId);
        }

        public async Task<int> GetCommentsCount(int postId)
        {
            return await _commentRepository.GetCommentsCount(postId);
        }
    }
}
