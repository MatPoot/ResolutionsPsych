using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ResolutionsPsych.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
            System.Diagnostics.Debug.WriteLine("OnGet()");
            Username = "username123";
            Password = "password123";
        }

        public IActionResult OnPost()
        {
            System.Diagnostics.Debug.WriteLine("OnPost()");
            bool authenticated = false;

            Classes.Login login = SqlHelper.GetLogin(Username);

            bool passwordVerified = Util.Verify(Password, login.Password);
            if (passwordVerified)
                authenticated = true;


            if (authenticated)
            {
                System.Diagnostics.Debug.WriteLine("User authenticated successfully");
                HttpContext.Session.Set("Username", Util.StringToByteArray(Username));
                HttpContext.Session.Set("StaffType", Util.StringToByteArray(login.StaffType));

                return new RedirectToPageResult("Index");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Login failed");
                return Page();
            }


        }
    }
}
