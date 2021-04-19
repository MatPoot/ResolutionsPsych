using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResolutionsPsych.Classes;

namespace ResolutionsPsych.Pages
{
    [BindProperties(SupportsGet =true)]
    public class UpdateStaffModel : PageModel
    {
        public Login ToUpdateStaff {get;set;}

        [Required(ErrorMessage = "name is required"), RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "name is invalid"),
           MaxLength(10, ErrorMessage = "name is too long")]
        public string NewUsername { get; set; }

        [Required, DataType(DataType.Password), MinLength(3), MaxLength(10)]
        public string NewPassword { get; set; }

        public string Message { get; set; }
        public IActionResult OnGet()
        {
            string username = HttpContext.Session.GetString("Username");
            System.Diagnostics.Debug.WriteLine($"UpdateStaff username: {username}");
            if (username == null || username == string.Empty)
                return new RedirectToPageResult("Index");

            ResolutionsSystem rs = new ResolutionsSystem();

            ToUpdateStaff = rs.GetLogin(HttpContext.Session.GetString("Username"));
            NewUsername = ToUpdateStaff.Username;
            NewPassword = ToUpdateStaff.Password;

            return Page();
           
            
        }
        public IActionResult OnPost()
        {
            ResolutionsSystem rs = new ResolutionsSystem();

            Login UpdatedLogin = new Login();
            UpdatedLogin.Username = NewUsername;
            UpdatedLogin.Password = Util.HashPassword(NewPassword);

           
            rs.UpdateLogin(UpdatedLogin);

            HttpContext.Session.Set("ToModifyStaffID", Util.StringToByteArray(""));

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
