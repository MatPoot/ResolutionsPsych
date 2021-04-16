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
    public class ViewClientsModel : PageModel
    {
        public List<Client> ListOfClients { get; set; }
        public int ClientToModify { get; set; }
        public IActionResult OnGet()
        {
            string username = GetSessionValue("Username");
            if (username == null || username == string.Empty)
                return new RedirectToPageResult("Index");

            ResolutionsSystem rs = new ResolutionsSystem();
            ListOfClients = rs.GetClients();

            return Page();
        }
        public IActionResult OnPost()
        {
            //need code here for delete client, need to write SQL stored procedure first
            //make sure to add a refresh page at the end
            //SqlCode code = ListOfClients..DeleteClient((int)ClientToModify);

            return new RedirectToPageResult("ViewClients");
        }

        public IActionResult OnPostDelete(int ClientID)
        {
            ResolutionsSystem rs = new ResolutionsSystem();
            Classes.Client client = new Client()
            {
                ClientID = ClientID
            };

            SqlCode code = rs.DeleteClient(client);
            System.Diagnostics.Debug.WriteLine($"Deleting client {ClientID}");
            return new RedirectToPageResult("ViewClients");
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
