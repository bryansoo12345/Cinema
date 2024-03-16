using Cinema.Data;
using Microsoft.AspNetCore.Identity;
using System;

namespace Cinema.Models.Utilities
{
    public static class Security
    {
        private static Random random = new Random();

        public static string HashPassword(string enteredPassword)
        {
            var passwordHasher = new PasswordHasher<string>();

            return passwordHasher.HashPassword(null, enteredPassword); 
        }

        public static bool VerifyPassword(string hashedPassword, string enteredPassword)
        {
            var passwordHasher = new PasswordHasher<string>();

            var result = passwordHasher.VerifyHashedPassword(null, hashedPassword, enteredPassword);

            if (result == PasswordVerificationResult.Success)
            {

                Console.WriteLine("Password is correct.");
                return true;
            }
            else
            {
                Console.WriteLine("Password is incorrect.");
                return false;
            }
        }

        public static string GenerateUniqueUserToken(ApplicationDbContext db, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] stringChars = new char[length];
            string potentialToken;

            do
            {
                for (int i = 0; i < length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                potentialToken = new String(stringChars);
            }
            // Check against the database to ensure uniqueness
            while (db.Account.Any(a => a.UserToken == potentialToken));

            return potentialToken;
        }

        
    }
}
