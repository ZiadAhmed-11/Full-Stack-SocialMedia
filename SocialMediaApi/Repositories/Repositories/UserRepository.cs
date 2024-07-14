using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using SocialMedia.Data.Data;
using SocialMedia.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _context;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IdentityResult> AddAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }

        public async Task SignInAsync(User user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user, isPersistent);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> FindByIdAsync(Guid userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public bool IsEmailAlreadyExist(string email)
        {
            return _userManager.Users.Any(u => u.Email.ToLower() == email.ToLower());

        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            var existingUser = await _userManager.FindByEmailAsync(user.UserName);
            if (existingUser == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            // Update user properties
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Age = DateTime.Now.Year - existingUser.BirthDay.Year;
            existingUser.Bio = user.Bio;
            existingUser.City = user.City;
            existingUser.Country = user.Country;
            existingUser.ProfileImageUrl = user.ProfileImageUrl;
            existingUser.CoverImageUrl = user.CoverImageUrl;
            existingUser.BirthDay = user.BirthDay;
            existingUser.Gender = user.Gender;

            return await _userManager.UpdateAsync(existingUser);
        }

        public async Task<List<User>> SearchUserAsync(string keyword)
        {

            return await _userManager.Users.Where(u=>u.FirstName.Contains(keyword)||u.LastName.Contains(keyword)).ToListAsync();
        }
    }
}
