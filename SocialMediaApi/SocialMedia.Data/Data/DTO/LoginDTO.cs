using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.Data.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email Can't be blank")]
        [EmailAddress(ErrorMessage = "Email Address is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password Can't be blank")]
        public string Password { get; set; }
    }
}
