using Microsoft.AspNetCore.Identity;
using Risk_Management_RiskEX_Backend.Data;
using System.Net;
using Risk_Management_RiskEX_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Risk_Management_RiskEX_Backend.Models;

namespace Risk_Management_RiskEX_Backend.Repository
{
    public class PasswordResetRepository: IPasswordResetRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public PasswordResetRepository(
            ApplicationDBContext db,
            IEmailService emailService,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _db = db;
            _emailService = emailService;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> SendPasswordResetEmailAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with email {email} not found.");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var frontendUrl = _configuration.GetValue<string>("AppSettings:FrontendUrl");
            var resetLink = $"{frontendUrl}/reset-password?token={WebUtility.UrlEncode(token)}";

            var subject = "Password Reset Request";
            var body = $@"
            Dear {user.FullName},

            You have requested to reset your password. Please click the link below to reset your password:

            {resetLink}

            This link will expire in 1 hour.

            If you didn't request this password reset, please ignore this email.

            Best regards,
            Risk Management Team
            Experion Technologies Pvt. Ltd.
        ";

            await _emailService.SendEmail(user.Email, subject, body);
            return true;
        }

        public async Task<bool> ValidateResetTokenAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
                return false;

            var user = await _db.Users.FirstOrDefaultAsync(u =>
                _userManager.VerifyUserTokenAsync(u, _userManager.Options.Tokens.PasswordResetTokenProvider,
                "ResetPassword", token).Result);

            return user != null;
        }

        public async Task<bool> ResetPasswordAsync(string token, string newPassword)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u =>
                _userManager.VerifyUserTokenAsync(u, _userManager.Options.Tokens.PasswordResetTokenProvider,
                "ResetPassword", token).Result);

            if (user == null)
                return false;

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }
    }

}

