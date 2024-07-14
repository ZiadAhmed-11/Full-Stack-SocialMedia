using System;
using System.Collections.Generic;

namespace SocialMedia.Data.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string? PostDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public string? ContentUrl { get; set; } = null;

        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Like>? Likes { get; set; }

        public Guid UserId { get; set; }
        public virtual User? User { get; set; }

        public Post()
        {
            CreatedAt = DateTime.Now;
        }
    }
}

