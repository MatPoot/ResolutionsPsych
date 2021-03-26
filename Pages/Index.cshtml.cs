using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResolutionsPsych.Pages
{
    
    public class IndexModel : PageModel
    {
        public string Username { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            SqlClasses.Clients clientHelper = new SqlClasses.Clients();
            List<Classes.Client> clients = clientHelper.GetClients();

            foreach(Classes.Client c in clients)
            {
                System.Diagnostics.Debug.WriteLine($"ClientID: {c.ClientID}");
                System.Diagnostics.Debug.WriteLine($"FirstName: {c.FirstName}");
                System.Diagnostics.Debug.WriteLine($"LastName: {c.LastName}");
            }
            //string plain = "a";
            //Random rand = new Random();

            
            //for(int i = 0; i < 10; ++i)
            //{
            //    string hashed = Util.HashPassword(plain);
            //    System.Diagnostics.Debug.WriteLine($"Plain: {plain} -- Hashed: {hashed}");
            //    plain += (char)rand.Next(97, 123);
            //}

            //AddTestLogin();

            Username = GetSessionValue("Username");

            Classes.Client testClient = new Classes.Client()
            {
                FirstName = "Wow",
                MiddleName = "Me",
                LastName = "Woah",
                Email = "abc123@",
                Phone = "1234",
                Address = "1234 56 Street"
            };

            Classes.Appointment testApp = new Classes.Appointment()
            {
                AppointmentDate = new DateTime(2021, 1, 5),
                ClientID = 1,
                CounsellorID = 1
            };



            //SqlCode code = SqlHelper.BookSQL(testApp);
            //SqlCode code = SqlHelper.CreateClient(testClient);
            //SqlCode code = SqlHelper.DeleteAppoinment(1);

            //System.Diagnostics.Debug.WriteLine($"Result: {code}");
        }

        public string GetSessionValue(string Key)
        {
            byte[] valueArray;
            string valueString;
            HttpContext.Session.TryGetValue(Key, out valueArray);

            if (valueArray != null)
                valueString = Util.ByteArrayToString(valueArray);
            else
                valueString = string.Empty;

            return valueString;
        }

        private void AddTestLogin()
        {
            string password = Util.HashPassword("password");

            //System.Diagnostics.Debug.WriteLine(password);

            Classes.Login login = new Classes.Login()
            {
                Username = "username123",
                Password = password,
                StaffType = "Counsellor"
            };

            SqlCode code = SqlHelper.CreateLogin(login);
        }
    }
}
