using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Repositories.Interfaces;
using SocialMedia.Data.Data.DTO;
using SocialMedia.Data.Models;
using SocialMedia.Data.Repositories;
using SocialMedia.Services.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SocialMedia.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task AddAsync(RegisterDTO registerUser)
        {
            User user = new User()
            {
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                UserName = registerUser.Email.ToLower(),
                BirthDay = registerUser.BirthDay,
                Gender = registerUser.Gender,
                PhoneNumber = registerUser.PhoneNumber,
                Age = DateTime.Now.Year - registerUser.BirthDay.Year
            };

            var result = await _userRepository.AddAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _userRepository.SignInAsync(user, isPersistent: false);
            }
            else
            {
                throw new Exception(string.Join(" | ", result.Errors.Select(e => e.Description)));
            }
        }

        public async Task<User> Login(LoginDTO loginDTO)
        {
            var result = await _userRepository.PasswordSignInAsync(
                loginDTO.Email,
                loginDTO.Password,
                isPersistent: false,
                lockoutOnFailure: false
            );

            if (!result.Succeeded)
            {
                throw new UnauthorizedAccessException("Invalid login attempt.");
            }

            var user = await _userRepository.FindByNameAsync(loginDTO.Email);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            return user;
        }

        public async Task Logout()
        {
            await _userRepository.SignOutAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByUserId(Guid userId)
        {
            _logger.LogInformation("GetUserByUserId of UserService");
            return await _userRepository.FindByIdAsync(userId);
        }

        public async Task<Guid> GetUserIdByUserNameAsync(string name)
        {
            _logger.LogInformation("GetUserByUserName of UserService");
            var user = await _userRepository.FindByNameAsync(name);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            return user.Id;
        }

        public bool IsEmailIsAlreadyExist(string email)
        {
            _logger.LogInformation("IsEmailAlreadyExist of UserService");
            _logger.LogDebug($"Is {email} Already Exist?");

            return _userRepository.IsEmailAlreadyExist(email);
        }

        public async Task<IdentityResult> UpdateUser(User user)
        {
            return await _userRepository.UpdateUserAsync(user);
        }

        public async Task<List<User>> SearchUser(string keyword)
        {
            _logger.LogInformation("SearchUser of UserService");
            return await _userRepository.SearchUserAsync(keyword);
        }

        public Task SendEmail(string email, string subject, string message)
        {
            var fromEmail = "tutorialseu-dev@outlook.com";
            var fromPassword = "Test12345678!";
            const string smtpHost = "smtp-mail.outlook.com";
            const int smtpPort = 587; // Use port 587 for TLS

            var client = new SmtpClient(smtpHost, smtpPort)
            {
                EnableSsl = true, // Ensure SSL is enabled
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail, fromPassword)
            };

            var mailMessage = new MailMessage(from: fromEmail, to: email, subject, message)
            {
                IsBodyHtml = true // Optional: Set this if the email body is HTML
            };

            return client.SendMailAsync(mailMessage);
        }
    }
}
