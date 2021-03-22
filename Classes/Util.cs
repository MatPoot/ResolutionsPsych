using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ResolutionsPsych
{
    public static class Util
    {
        public static byte[] StringToByteArray(string s)
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(s);
            return array;
        }

        public static string ByteArrayToString(byte[] array)
        {
            string s = System.Text.Encoding.Default.GetString(array);
            return s;
        }

        public static string GetConnectionString()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("Default");

            return connectionString;
        }

        #region Security
        private static int size = 16;

        public static string HashPassword(string Password)
        {
            byte[] salt = GenerateSalt(size);
            byte[] bytes = KeyDerivation.Pbkdf2(Password, salt, KeyDerivationPrf.HMACSHA1, 10000, size);

            string returnVal = $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(bytes)}";
            return returnVal;
        }
        public static bool Verify(string PlainPassword, string HashedPassword)
        {
            string[] parts = HashedPassword.Split(':');
            byte[] salt = Convert.FromBase64String(parts[0]);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(PlainPassword, salt, KeyDerivationPrf.HMACSHA1, 10000, size));

            bool matched = parts[1] == hashed;

            return matched;
        }
        private static byte[] GenerateSalt(int Length)
        {
            byte[] salt = new byte[Length];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
        #endregion


    }
}
