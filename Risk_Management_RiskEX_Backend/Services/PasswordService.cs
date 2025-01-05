﻿

using Microsoft.AspNetCore.Identity;
using System;
namespace Risk_Management_RiskEX_Backend.Services
{


    public class PasswordService
    {
        private readonly PasswordHasher<object> _passwordHasher;

        public PasswordService()
        {
            _passwordHasher = new PasswordHasher<object>(); // You can pass any object type here, such as User
        }

        // Hash the password
        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);  // `null` is passed because we don't need a user object here.
        }

        // Verify the password
        public bool VerifyPassword(string hashedPassword, string passwordToCheck)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, passwordToCheck);
            return result == PasswordVerificationResult.Success;
        }
    }

}
