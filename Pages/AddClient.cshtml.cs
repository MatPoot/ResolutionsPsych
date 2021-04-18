using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResolutionsPsych;
using ResolutionsPsych.Classes;
using System.ComponentModel.DataAnnotations;

namespace ResolutionsPsych.Pages
{
    [BindProperties]
    public class AddClientModel : PageModel
    {
        [BindProperty, Required(ErrorMessage = "First name is required"), RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "First name is invalid"),
            MaxLength(10, ErrorMessage = "First name is too long")]
        public string FName { get; set; }

        [BindProperty, RegularExpression(@"^[A-Za-z]*$", ErrorMessage = "Middle name is invalid"),
            MaxLength(20, ErrorMessage = "Middle name is too long")]
        public string MName { get; set; }

        [BindProperty, Required(ErrorMessage = "Last name is required"), RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Last name is invalid"),
            MaxLength(20, ErrorMessage = "Last name is too long")]
        public string LName { get; set; }

        [BindProperty, Required(ErrorMessage = "Email is required"), RegularExpression(@"^[^<> ]+@\w+\.[a-z]+$", ErrorMessage = "Invalid email"),
            MaxLength(50, ErrorMessage = "Email is too long")]
        public string Email { get; set; }

        [BindProperty, Required(ErrorMessage = "Phone number is required"), RegularExpression(@"^[\d()\- ]+$", ErrorMessage = "Invalid phone number"),
            MaxLength(24, ErrorMessage = "Phone number too long")]
        public string Phone { get; set; }

        [BindProperty, Required(ErrorMessage = "Address is required"), RegularExpression(@"^[A-Za-z0-9. ]+$", ErrorMessage = "Address is required"),
            MaxLength(50, ErrorMessage = "Address is too long")]
        public string Address { get; set; }

        public string Message { get; set; }


        #region Request Handlers
        public IActionResult OnGet()
        {
            string username = GetSessionValue("Username");
            if (username == null || username == string.Empty)
                return new RedirectToPageResult("Index");
            else
                return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            Client AddClient = new Client();
            AddClient.FirstName = FName;
            AddClient.LastName = LName;
            AddClient.MiddleName = MName;
            AddClient.Email = Email;
            AddClient.Phone = Phone;
            AddClient.Address = Address;

            ResolutionsSystem rs = new ResolutionsSystem();
            SqlCode code = rs.CreateClient(AddClient);

            return new RedirectToPageResult("Index");
        }

        #endregion

        #region Helper Methods
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
        #endregion
    }

}
