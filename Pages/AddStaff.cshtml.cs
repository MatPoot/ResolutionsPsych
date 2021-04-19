using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ResolutionsPsych.Classes;

namespace ResolutionsPsych.Pages
{
    [BindProperties]
    public class AddStaffModel : PageModel
    {
       [Required(ErrorMessage = "name is required"), RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "name is invalid"),
            MaxLength(10, ErrorMessage = "name is too long")]
        public string Username { get; set; }

        [Required, DataType(DataType.Password), MinLength(3),MaxLength(10)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), MinLength(3), MaxLength(10)]
        public string PasswordConfirm { get; set; }

       [Required]
        public string StaffType { get; set; }
        public string CounsellorName { get; set; }

        public string Message { get; set; }


        public void OnGet()
        {
            //System.Diagnostics.Debug.WriteLine("AddStaff OnGet()");
        }

        public IActionResult OnPost()
        {
            System.Diagnostics.Debug.WriteLine("OnPost()");

            if (ModelState.IsValid)
            {
                ResolutionsSystem rs = new ResolutionsSystem();

                Login AddLogin = new Login();
                AddLogin.Username = Username;
                AddLogin.Password = Password;
                AddLogin.StaffType = StaffType;

                // This one form can do two things, create a login for staff, AND create a counsellor login
                // below the code checks and creates 1 or 2 objects respectively depending if there is a counsellor being added or not
                // edit the SQL stored procedure and resolutionspsych to add new counsellor if needed with the createLogin method path


                if  (CounsellorName.Length==0){
               

                    SqlCode code = rs.CreateLogin(AddLogin);
                }
                else
                {
                    Counsellor AddCounsellor = new Counsellor();
                    AddCounsellor.Name = CounsellorName;
              //      SqlCode code = rs.CreateLogin(AddLogin,AddCounsellor);
                }









                Message = "New Staff Added";

                return Page();

            }
            else
            {
            System.Diagnostics.Debug.WriteLine($"StaffType: {StaffType}");
            return Page();
            }
          
            

           
        }
    }
}
