using Microsoft.AspNetCore.Mvc;
using SocialMedia.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.Data.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage ="First name can't be blank")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name can't be blank")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        [Remote(action: "IsEmailIsAlreadyExist", controller: "User", ErrorMessage = "Email is already in use")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password can't be blank")]
        public string  Password { get; set; }

        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [Compare("Password",ErrorMessage ="Password and confirm password don't match")]
        public string ConfirmationPassword { get; set; }

        [Required(ErrorMessage = "Phone number can't be blank")]
        [Phone(ErrorMessage = "Phone number is invalid")]
        public string PhoneNumber { get; set; }

        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }

    }
}
