using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResolutionsPsych.Classes;

namespace ResolutionsPsych.Pages
{
    [BindProperties(SupportsGet =true)]
    public class ViewAppointmentsModel : PageModel
    {
        public List<Appointment> ListOfAppointments { get; set; }
       
        public IActionResult OnGet()
        {
            string username = GetSessionValue("Username");
            if (username == null || username == string.Empty)
                return new RedirectToPageResult("Index");
         
            ListOfAppointments = SqlHelper.GetAppointments();

            return Page();
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
