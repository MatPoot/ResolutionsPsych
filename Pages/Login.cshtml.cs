using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ResolutionsPsych.Pages
{
    public class LoginModel : PageModel
    {
        //Remote validation doesn't seem to work at this time. Leaving it in just in case
        [PageRemote(
            ErrorMessage = "Username doesn't exist",
            AdditionalFields = "__RequestVerificationToken",
            HttpMethod = "post",
            PageHandler = "CheckUsername"
            )]
        [BindProperty, Required(ErrorMessage = "Username is required"), MaxLength(20, ErrorMessage = "Username must be between 1 and 20 characters")]
        public string Username { get; set; }

        [BindProperty, Required(ErrorMessage = "Password is required"), DataType(DataType.Password), 
            MaxLength(20, ErrorMessage = "Password is too long")]
        public string Password { get; set; }

        public void OnGet()
        {

        }

        public JsonResult OnPostCheckUsername()
        {
            System.Diagnostics.Debug.WriteLine("OnPostCheckUsername()");

            ResolutionsSystem rs = new ResolutionsSystem();
            Classes.Login login = rs.GetLogin(Username);

            bool valid = false;
            if (login.Username == null)
                valid = false;
            else
                valid = true;

            return new JsonResult(valid);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            
            System.Diagnostics.Debug.WriteLine("OnPost()");
            bool authenticated = false;

            ResolutionsSystem rs = new ResolutionsSystem();
            Classes.Login login = rs.GetLogin(Username);
            System.Diagnostics.Debug.WriteLine($"Hash pass: {login.Password}");


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
