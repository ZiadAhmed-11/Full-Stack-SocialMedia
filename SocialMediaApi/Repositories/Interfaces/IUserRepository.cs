using Microsoft.AspNetCore.Identity;
using SocialMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddAsync(User user, string password);
        Task<User> FindByNameAsync(string userName);
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task SignInAsync(User user, bool isPersistent);
        Task SignOutAsync();
        Task<List<User>> GetAllUsersAsync();
        Task<User> FindByIdAsync(Guid userId);
        bool IsEmailAlreadyExist(string email);
        Task<IdentityResult> UpdateUserAsync(User user);
        Task<List<User>> SearchUserAsync(string keyword);

    }
}
