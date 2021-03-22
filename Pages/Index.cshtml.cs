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

            Classes.Appointments testApp = new Classes.Appointments()
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
    }
}
