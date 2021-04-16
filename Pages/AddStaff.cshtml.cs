using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ResolutionsPsych.Pages
{
    public class AddStaffModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [BindProperty]
        public string StaffType { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            System.Diagnostics.Debug.WriteLine($"StaffType: {StaffType}");
            return Page();
        }
    }
}
