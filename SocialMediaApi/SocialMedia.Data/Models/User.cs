using Microsoft.AspNetCore.Identity;
using SocialMedia.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.Models
{
    public class User:IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age{get;set; }
        public string? Bio { get; set; } = null;
        public string? City { get; set; } =null;
        public string? Country { get; set; } =null;
        public string? ProfileImageUrl { get; set; } = null;
        public string? CoverImageUrl { get; set; } = null;
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }

        public ICollection<Post>? Posts { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
