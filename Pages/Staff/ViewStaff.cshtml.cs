using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResolutionsPsych.SqlClasses;

namespace ResolutionsPsych.Pages.Staff
{
    public class ViewStaffModel : PageModel
    {
        List<Logins> StaffList { get; set; }
        public void OnGet()
        {
        }
    }
}
