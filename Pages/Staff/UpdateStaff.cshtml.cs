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
            


            ResolutionsSystem rs = new ResolutionsSystem();

            if (HttpContext.Session.GetString("ToModifyStaffID") == "")
            {
                return new RedirectToPageResult("Index");
            }

            ToUpdateStaff = rs.GetLogin(HttpContext.Session.GetString("ToModifyStaffID"));
            NewUsername = ToUpdateStaff.Username;
            NewPassword = ToUpdateStaff.Password;

            return Page();
           
            
        }
        public IActionResult OnPost()
        {
            ResolutionsSystem rs = new ResolutionsSystem();

            Login UpdatedLogin = new Login();
            UpdatedLogin.Username = NewUsername;
            UpdatedLogin.Password = NewPassword;

            rs.UpdateLogin(UpdatedLogin);

            HttpContext.Session.Set("ToModifyStaffID", Util.StringToByteArray(""));

            return Page();
        }
    }
}
