using Microsoft.AspNetCore.Identity;
using SocialMedia.Data.Data.DTO;
using SocialMedia.Data.Enums;
using SocialMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services.ServiceContracts
{
    public interface IUserService
    {
        Task AddAsync(RegisterDTO register);
        Task<User> Login(LoginDTO loginDTO);
        Task Logout();
        Task<Guid> GetUserIdByUserNameAsync(string Name);
        Task<User> GetUserByUserId(Guid userId);
        Task<IdentityResult> UpdateUser(User user);
        Task<List<User>> GetAllUsersAsync();
        bool IsEmailIsAlreadyExist(string Email);
        Task<List<User>> SearchUser(string keyword);
        Task SendEmail(string email, string subject, string message);
    }
}
