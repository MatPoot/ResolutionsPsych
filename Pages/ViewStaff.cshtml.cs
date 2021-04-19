using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResolutionsPsych.SqlClasses;
using ResolutionsPsych.Classes;

namespace ResolutionsPsych.Pages.Staff
{
    [BindProperties(SupportsGet = true)]
    public class ViewStaffModel : PageModel
    {
        public List<Login> StaffList { get; set; }
        public string StaffToModify { get; set; }
        public IActionResult OnGet()
        {


            //string username = GetSessionValue("Username");
            //if (username == null || username == string.Empty)
            //    return new RedirectToPageResult("Index");


            ResolutionsSystem rs = new ResolutionsSystem();
            //StaffList = rs.GetLogins();
            // need GetAllLogins function and stored procedure

            return Page();
        }
        public IActionResult OnPost()
        {
            HttpContext.Session.Set("ToModifyStaffID", Util.StringToByteArray(StaffToModify));
            return new RedirectToPageResult("UpdateStaff");
        }
    }
}
