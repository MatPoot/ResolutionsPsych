using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PsychApp;
using PsychApp.Classes;

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
        public void OnGet()
        {
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

            SqlHelper.CreateClient(AddClient);
       

        return new RedirectToPageResult("Index");
    }
    }
   
}
