using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ResolutionsPsych.Pages
{
    public class DeleteAppointmentModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? AppointmentID { get; set; }


        public IActionResult OnGet()
        {
            string username = GetSessionValue("Username");
            if (username == null || username == string.Empty)
                return new RedirectToPageResult("Index");

            if (AppointmentID == null)
                return new RedirectToPageResult("Index");

            SqlCode code = SqlHelper.DeleteAppoinment((int)AppointmentID);

            return new RedirectToPageResult("ViewAppointments");
        }

        private string GetSessionValue(string Key)
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
