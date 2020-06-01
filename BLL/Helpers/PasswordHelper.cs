using BLL.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;

namespace BLL.Helpers
{
    public static class PasswordHelper
    {
        static public UserModel WithoutPassword(this UserModel user)
        {
            if (user == null)
                return null;

            user.PasswordHash = null;
            user.Token = null;
            return user;
        }

        static public IEnumerable<UserModel> WithoutPasswords(this IEnumerable<UserModel> users)
        {

            foreach (UserModel user in users)
            {
                user.PasswordHash = null;
                user.Token = null;
            }
            return users;
        }
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
