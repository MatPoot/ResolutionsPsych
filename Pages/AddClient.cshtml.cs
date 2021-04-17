using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResolutionsPsych;
using ResolutionsPsych.Classes;

namespace ResolutionsPsych.Pages
{
    [BindProperties]
    public class AddClientModel : PageModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
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
