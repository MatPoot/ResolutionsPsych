using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

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


    }
}
