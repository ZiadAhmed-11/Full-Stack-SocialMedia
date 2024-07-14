using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? CommentContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid Author { get; set; }
        public virtual User? User { get; set; }
        public int PostId { get; set; }
        public virtual Post? Post { get; set; }
    }
}
