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
            if (AppointmentID == null)
                return new RedirectToPageResult("Index");

            SqlCode code = SqlHelper.DeleteAppoinment((int)AppointmentID);

            return new RedirectToPageResult("ViewAppointments");
        }
    }
}
